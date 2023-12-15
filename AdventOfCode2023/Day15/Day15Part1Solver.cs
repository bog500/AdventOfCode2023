using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day15
{
    public class Day15Part1Solver : Day15BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            string ans = base.Hashes(lines[0]).ToString();

            //string ans = base.Hash("HASH").ToString();
            
            return ans;
        }
    }
}
