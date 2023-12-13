using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day12
{
    public class Spring
    {
        public string SpringString { get; set; }


        public List<int> Arrangements { get; init; } = new();

        public List<string> Alternates { get; init; } = new();

        public Spring(string line)
        {
            SpringString = line.Split(' ')[0];
            Arrangements = Parser.ParseInt(line.Split(' ')[1], ',');
            Alternates = GetAlternatives(SpringString);
        }

        private bool EarlyStop(string s)
        {
            while (s.Contains(".."))
                s = s.Replace("..", ".");

            if (s.EndsWith('.'))
                s = s.Remove(s.Length - 1);

            if (s.StartsWith('.'))
                s = s.Remove(0, 1);

            int count = s.Split('.').Count();
            if (count-3 > Arrangements.Count)
                return true;

            if (4 + count + (s.Count(o => o == '?') / 2) < Arrangements.Count)
                return true;

            return false;
        }

        

        public List<string> GetAlternatives(string s)
        {
            List<string> alternates = new();

            if (CheckedList.Contains(s))
                return alternates;

            CheckedList.Add(s);

            int pos = 0;
            char[] chars = s.ToCharArray();

            foreach (char c in s)
            {
                if (c == '?')
                {
                    char[] chars1 = (char[])chars.Clone();
                    char[] chars2 = (char[])chars.Clone();

                    chars1[pos] = '.';
                    chars2[pos] = '#';

                    alternates.AddRange(GetAlternatives(new string(chars1)));
                    alternates.AddRange(GetAlternatives(new string(chars2)));

                    break;
                }
                pos++;
            }
            if (IsValid(s))
                alternates.Add(s);

            return alternates;
        }

        HashSet<string> CheckedList = new();



        private bool IsValid(string s)
        {
            if (s.Contains('?'))
                return false;

            while (s.Contains(".."))
                s = s.Replace("..", ".");

            if (s.EndsWith('.'))
                s = s.Remove(s.Length - 1);

            if (s.StartsWith('.'))
                s = s.Remove(0, 1);

            var arr = s.Split('.');
            if (arr.Count() != Arrangements.Count)
                return false;

            for (int i = 0; i < Arrangements.Count; i++)
            {
                if (arr[i].Length != Arrangements[i])
                    return false;
            }

            return true;
        }
    }
}
