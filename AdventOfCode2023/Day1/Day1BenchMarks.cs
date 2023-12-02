using AdventOfCode2023.Common;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Day1
{
    public class Day1BenchMarks
    {
        private ClueReader cr = new ClueReader(DayEnum.Day1);

        private Day1Part1Solver part1Solver = new Day1Part1Solver();
        private Day1Part2Solver part2Solver = new Day1Part2Solver();

        List<string> demo1Lines;
        List<string> demo2Lines;
        List<string> clueLines;

        public Day1BenchMarks()
        {
            demo1Lines = cr.Read(FileEnum.Demo1);
            demo2Lines = cr.Read(FileEnum.Demo2);
            clueLines = cr.Read(FileEnum.Clue);
        }

        [Benchmark]
        public void Demo1()
        {
            part1Solver.Solve(demo1Lines);
        }

        [Benchmark]
        public void Demo2()
        {
            part2Solver.Solve(demo2Lines);
        }

        [Benchmark]
        public void Part1()
        {
            part1Solver.Solve(clueLines);
        }

        [Benchmark]
        public void Part2()
        {
            part2Solver.Solve(clueLines);
        }
    }
}
