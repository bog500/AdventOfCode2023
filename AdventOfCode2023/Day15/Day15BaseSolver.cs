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

        private static Dictionary<string, long> dict = new();

        public long Hash(string str)
        {
            if(dict.ContainsKey(str))
                return dict[str];

            long val = 0;

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

        public long Hashes(string strs)
        {
            return Hashes(strs.Split(','));
        }

        public long Hashes(string[] strs)
        {
            long total = 0;

            foreach(var str in strs)
            {
                long hash = Hash(str);
                total += hash;
            }

            return total;
        }

    }


}
