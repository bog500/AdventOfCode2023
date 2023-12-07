using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day6
{
    public class Day6Part2Solver : Day6BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var races = base.Parse(lines).ToList();

            var errorMaging = CalcErrorMargin(races);

            return errorMaging.ToString();
        }

        protected override string FormatLine(string line)
        {
            return line.Replace(" ", "");
        }
    }
}
