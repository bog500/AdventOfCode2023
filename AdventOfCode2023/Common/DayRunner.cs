using AdventOfCode2023.Common;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023
{
    public class DayRunner<T1, T2> : IDayRunner
        where T1 : IPartSolver, new()
        where T2 : IPartSolver, new()
    {
        
        private readonly ClueReader cr;

        private readonly T1 part1Solver;
        private readonly T2 part2Solver;

        protected readonly List<string> demo1Lines;
        protected readonly List<string> demo2Lines;
        protected readonly List<string> clueLines;

        public DayRunner(DayEnum day)
        {
            Console.WriteLine("=====================");
            Console.WriteLine("   " + day.ToString());
            Console.WriteLine("=====================");

            cr = new ClueReader(day);

            part1Solver = new();
            part2Solver = new();

            demo1Lines = cr.Read(FileEnum.Demo1);
            demo2Lines = cr.Read(FileEnum.Demo2);
            clueLines = cr.Read(FileEnum.Clue);
        }

        public void RunAll()
        {
            Demo1();
            Part1();
            Console.WriteLine("----------------------");
            Demo2();
            Part2();

        }

        public void Demo1()
        {
            using (new CodeTimer())
            {
                var ans = part1Solver.Solve(demo1Lines);
                ConsoleWritter.Answer(PartEnum.Demo1, ans);
            }
        }

        public void Demo2()
        {
            using (new CodeTimer())
            {
                var ans = part2Solver.Solve(demo1Lines);
                ConsoleWritter.Answer(PartEnum.Demo2, ans);
            }
        }

        public void Part1()
        {
            using (new CodeTimer())
            {
                var ans = part1Solver.Solve(clueLines);
                ConsoleWritter.Answer(PartEnum.Part1, ans);
            }
        }

        public void Part2()
        {
            using (new CodeTimer())
            {
                var ans = part2Solver.Solve(clueLines);
                ConsoleWritter.Answer(PartEnum.Part2, ans);
            }
        }
    }
}
