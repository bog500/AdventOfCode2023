using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day5
{
    public class Day5Part2Solver : Day5BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            data = base.Parse(lines);

            long minValue = RunParallele().Result;

            return minValue.ToString();
        }

        private async Task<long> RunParallele()
        {
            long minValue = long.MaxValue;

            List<Task<long>> tasks = new();

            foreach (var pair in data.SeedRanges)
            {
                ConsoleWritter.WriteLine($"checking {pair.SeedStart}...");
                for (long seed = pair.SeedStart; seed < pair.SeedStart + pair.Range; seed++)
                {
                    tasks.Add(GetLocation(seed));
                }
                await Task.WhenAll(tasks);
                ConsoleWritter.WriteLine($"checking {pair.SeedStart}...");
            }

            foreach (var t in tasks)
            {
                long location = t.Result;

                if (location < minValue)
                    minValue = location;
            }

            return minValue;
        }

    }
}
