using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day11
{
    public class Day11Part1Solver : Day11BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var ans = base.CalcDistance(lines);
            return ans.ToString();
        }
    }


}
