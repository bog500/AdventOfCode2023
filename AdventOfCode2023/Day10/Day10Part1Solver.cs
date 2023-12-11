using AdventOfCode2023.Common;
using AdventOfCode2023.Day10.Files;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day10
{
    public class Day10Part1Solver : Day10BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            CreateMaze(lines);
            SetStart();
            CheckMainLoop();

            var steps = mainLoop.Count / 2;

            return steps.ToString();
        }

    }
}
