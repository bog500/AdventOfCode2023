﻿using AdventOfCode2023.Common;
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
    [MemoryDiagnoser]
    public class DayRunner<T> : IDayRunner
        where T : IPartSolver, new()
    {
        
        private readonly ClueReader cr;

        private readonly T solver;

        protected readonly List<string> demoLines;
        protected readonly List<string> clueLines;

        private DayEnum Day;
        private PartEnum Part;

        private void SetEnums()
        {
            Day = Enum.Parse<DayEnum>(typeof(T).Name
                .Replace("Part1","")
                .Replace("Part2", "")
                .Replace("Solver",""));

            Part = typeof(T).Name.Contains("Part1") ? PartEnum.Part1 : PartEnum.Part2;
        }

        public DayRunner(): this(FileEnum.Default)
        {

        }

        public DayRunner(FileEnum file = FileEnum.Default)
        {
            SetEnums();

            ConsoleWritter.WriteLine("=====================");
            ConsoleWritter.Write("   " + Day.ToString(), ConsoleColor.Yellow);
            ConsoleWritter.WriteLine("   " + Part.ToString(), ConsoleColor.White);
            ConsoleWritter.WriteLine("=====================");

            cr = new ClueReader(Day);

            solver = new();

            demoLines = cr.Read(GetFile(file, DemoEnum.Demo, Part));
            clueLines = cr.Read(GetFile(file, DemoEnum.Real, Part));
        }

        private FileEnum GetFile(FileEnum file, DemoEnum demoreal, PartEnum part)
        {
            return (file, demoreal, part) switch
            {
                (FileEnum.Default, DemoEnum.Demo, PartEnum.Part1) => FileEnum.Demo1,
                (FileEnum.Default, DemoEnum.Demo, PartEnum.Part2) => FileEnum.Demo2,
                (FileEnum.Default, DemoEnum.Real, _) => FileEnum.Clue,
                (_,_, _) => file,
            };
        }

        [Benchmark]
        public void Demo()
        {
            using (new CodeTimer())
            {
                var ans = solver.Solve(demoLines);
                ConsoleWritter.Answer(DemoEnum.Demo, ans);
            }
        }

        [Benchmark]
        public void Real()
        {
            using (new CodeTimer())
            {
                var ans = solver.Solve(clueLines);
                ConsoleWritter.Answer(DemoEnum.Real, ans);
            }
        }


        public IPartSolver GetSolver() => solver;
    }
}
