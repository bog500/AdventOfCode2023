using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day15
{
    public abstract class Day15BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> line);

        private static Dictionary<string, int> dict = new();

        public int Hash(string str)
        {
            if(dict.ContainsKey(str))
                return dict[str];

            int val = 0;

            foreach(char c in str)
            {
                int i = c;
                val += i;
                val *= 17;
                val = val % 256;
            }

            dict.Add(str, val);

            return val;
        }

        public int Hashes(string strs)
        {
            return Hashes(strs.Split(','));
        }

        public int Hashes(string[] strs)
        {
            int total = 0;

            foreach(var str in strs)
            {
                int hash = Hash(str);
                total += hash;
            }

            return total;
        }

    }


}
