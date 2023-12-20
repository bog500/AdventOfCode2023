using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day19
{
    public class Day19Part1Solver : Day19BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            base.ParseAll(lines);
            var ans = base.Run();
            return ans.ToString();
        }
    }
}
