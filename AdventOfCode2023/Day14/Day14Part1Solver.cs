using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day14
{
    public class Day14Part1Solver : Day14BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var platform = base.Parse(lines);

            platform.TiltNorth();

            // platform.Print();

            var load = platform.GetLoad();

            return load.ToString();
        }
    }
}
