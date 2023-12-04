using AdventOfCode2023.Day1;
using AdventOfCode2023.Day2;
using AdventOfCode2023.Day3;
using AdventOfCode2023.Day4;
using AdventOfCode2023.Day5;
using AdventOfCode2023.Day6;
using AdventOfCode2023.Day7;
using AdventOfCode2023.Day8;
using AdventOfCode2023.Day9;
using AdventOfCode2023.Day10;
using AdventOfCode2023.Day11;
using AdventOfCode2023.Day12;
using AdventOfCode2023.Day13;
using AdventOfCode2023.Day14;
using AdventOfCode2023.Day15;
using AdventOfCode2023.Day16;
using AdventOfCode2023.Day17;
using AdventOfCode2023.Day18;
using AdventOfCode2023.Day19;
using AdventOfCode2023.Day20;
using AdventOfCode2023.Day21;
using AdventOfCode2023.Day22;
using AdventOfCode2023.Day23;
using AdventOfCode2023.Day24;
using AdventOfCode2023.Day25;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Common
{
    public static class DayRunners
    {
        public static IEnumerable<IDayRunner> GetAll()
        {
            foreach(var day in Enum.GetValues<DayEnum>())
            {
                yield return Get(day);
            }
        }

        public static IDayRunner Get(DayEnum day)
        {
            return day switch
            {
                DayEnum.Day1 => new DayRunner<Day1Part1Solver, Day1Part2Solver>(DayEnum.Day1),
                DayEnum.Day2 => new DayRunner<Day2Part1Solver, Day2Part2Solver>(DayEnum.Day2),
                DayEnum.Day3 => new DayRunner<Day3Part1Solver, Day3Part2Solver>(DayEnum.Day3),
                DayEnum.Day4 => new DayRunner<Day4Part1Solver, Day4Part2Solver>(DayEnum.Day4),
                DayEnum.Day5 => new DayRunner<Day5Part1Solver, Day5Part2Solver>(DayEnum.Day5),
                DayEnum.Day6 => new DayRunner<Day6Part1Solver, Day6Part2Solver>(DayEnum.Day6),
                DayEnum.Day7 => new DayRunner<Day7Part1Solver, Day7Part2Solver>(DayEnum.Day7),
                DayEnum.Day8 => new DayRunner<Day8Part1Solver, Day8Part2Solver>(DayEnum.Day8),
                DayEnum.Day9 => new DayRunner<Day9Part1Solver, Day9Part2Solver>(DayEnum.Day9),
                DayEnum.Day10 => new DayRunner<Day10Part1Solver, Day10Part2Solver>(DayEnum.Day10),
                DayEnum.Day11 => new DayRunner<Day11Part1Solver, Day11Part2Solver>(DayEnum.Day11),
                DayEnum.Day12 => new DayRunner<Day12Part1Solver, Day12Part2Solver>(DayEnum.Day12),
                DayEnum.Day13 => new DayRunner<Day13Part1Solver, Day13Part2Solver>(DayEnum.Day13),
                DayEnum.Day14 => new DayRunner<Day14Part1Solver, Day14Part2Solver>(DayEnum.Day14),
                DayEnum.Day15 => new DayRunner<Day15Part1Solver, Day15Part2Solver>(DayEnum.Day15),
                DayEnum.Day16 => new DayRunner<Day16Part1Solver, Day16Part2Solver>(DayEnum.Day16),
                DayEnum.Day17 => new DayRunner<Day17Part1Solver, Day17Part2Solver>(DayEnum.Day17),
                DayEnum.Day18 => new DayRunner<Day18Part1Solver, Day18Part2Solver>(DayEnum.Day18),
                DayEnum.Day19 => new DayRunner<Day19Part1Solver, Day19Part2Solver>(DayEnum.Day19),
                DayEnum.Day20 => new DayRunner<Day20Part1Solver, Day20Part2Solver>(DayEnum.Day20),
                DayEnum.Day21 => new DayRunner<Day21Part1Solver, Day21Part2Solver>(DayEnum.Day21),
                DayEnum.Day22 => new DayRunner<Day22Part1Solver, Day22Part2Solver>(DayEnum.Day22),
                DayEnum.Day23 => new DayRunner<Day23Part1Solver, Day23Part2Solver>(DayEnum.Day23),
                DayEnum.Day24 => new DayRunner<Day24Part1Solver, Day24Part2Solver>(DayEnum.Day24),
                DayEnum.Day25 => new DayRunner<Day25Part1Solver, Day25Part2Solver>(DayEnum.Day25),
            };
        }
    }
}
