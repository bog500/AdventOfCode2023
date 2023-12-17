using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Day16
{
    public class Day16Part2Solver : Day16BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int ans = RunAll(lines);

            return ans.ToString();
        }

        protected int RunAll(List<string> lines)
        {
            char[,] layout = GetLayout(lines);

            List<Task<int>> tasks = new();

            int lenX = layout.GetLength(0);
            int lenY = layout.GetLength(1);

            for (int x = 0; x < lenX; x++)
            {
                var beams1 = new List<Beam>() { new Beam((x, -1), Direction.Down) };
                var beams2 = new List<Beam>() { new Beam((x, lenY), Direction.Up) };

                tasks.Add(RunOneSimulation(layout, beams1));
                tasks.Add(RunOneSimulation(layout, beams2));
            }

            for (int y = 0; y < lenY; y++)
            {
                var beams1 = new List<Beam>() { new Beam((-1, y), Direction.Right) };
                var beams2 = new List<Beam>() { new Beam((lenX, y), Direction.Left) };

                tasks.Add(RunOneSimulation(layout, beams1));
                tasks.Add(RunOneSimulation(layout, beams2));
            }

            Task.WhenAll(tasks);

            int max = 0;

            foreach(var t in tasks)
            {
                max = Math.Max(max, t.Result);
            }

            return max;
        }

        protected async Task<int> RunOneSimulation(char[,] layout, List<Beam> beams)
        {
            await Task.Delay(0);
            BeamSimulator bs = new(layout, beams);

            bs.Simulate();

            return bs.GetEnergized();
        }
    }
}
