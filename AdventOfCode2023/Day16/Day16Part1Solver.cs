using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;


namespace AdventOfCode2023.Day16
{
    public class Day16Part1Solver : Day16BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int ans = Run(lines);

            return ans.ToString();
        }

        protected int Run(List<string> lines)
        {
            char[,] layout = GetLayout(lines);

            var beams = new List<Beam>()
            {
                new Beam((-1, 0), Direction.Right)
            };

            BeamSimulator bs = new(layout, beams);

            bs.Simulate();

            return bs.GetEnergized();
        }

    }
}
