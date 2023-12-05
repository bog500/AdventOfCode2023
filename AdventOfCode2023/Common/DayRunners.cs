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
using static BenchmarkDotNet.Attributes.MarkdownExporterAttribute;

namespace AdventOfCode2023.Common
{
    public static class DayRunners
    {
        public static IEnumerable<IDayRunner> GetAll()
        {
            foreach(var day in Enum.GetValues<DayEnum>())
            {
                yield return Get(day, PartEnum.Part1);
                yield return Get(day, PartEnum.Part2);
            }
        }

        public static IDayRunner Get(DayEnum day, PartEnum part, FileEnum file = FileEnum.Default)
        {
            return (day, part) switch
            {
                (DayEnum.Day1, PartEnum.Part1) => new DayRunner<Day1Part1Solver>(file),
                (DayEnum.Day2, PartEnum.Part1) => new DayRunner<Day2Part1Solver>(file),
                (DayEnum.Day3, PartEnum.Part1) => new DayRunner<Day3Part1Solver>(file),
                (DayEnum.Day4, PartEnum.Part1) => new DayRunner<Day4Part1Solver>(file),
                (DayEnum.Day5, PartEnum.Part1) => new DayRunner<Day5Part1Solver>(file),
                (DayEnum.Day6, PartEnum.Part1) => new DayRunner<Day6Part1Solver>(file),
                (DayEnum.Day7, PartEnum.Part1) => new DayRunner<Day7Part1Solver>(file),
                (DayEnum.Day8, PartEnum.Part1) => new DayRunner<Day8Part1Solver>(file),
                (DayEnum.Day9, PartEnum.Part1) => new DayRunner<Day9Part1Solver>(file),
                (DayEnum.Day10, PartEnum.Part1) => new DayRunner<Day10Part1Solver>(file),
                (DayEnum.Day11, PartEnum.Part1) => new DayRunner<Day11Part1Solver>(file),
                (DayEnum.Day12, PartEnum.Part1) => new DayRunner<Day12Part1Solver>(file),
                (DayEnum.Day13, PartEnum.Part1) => new DayRunner<Day13Part1Solver>(file),
                (DayEnum.Day14, PartEnum.Part1) => new DayRunner<Day14Part1Solver>(file),
                (DayEnum.Day15, PartEnum.Part1) => new DayRunner<Day15Part1Solver>(file),
                (DayEnum.Day16, PartEnum.Part1) => new DayRunner<Day16Part1Solver>(file),
                (DayEnum.Day17, PartEnum.Part1) => new DayRunner<Day17Part1Solver>(file),
                (DayEnum.Day18, PartEnum.Part1) => new DayRunner<Day18Part1Solver>(file),
                (DayEnum.Day19, PartEnum.Part1) => new DayRunner<Day19Part1Solver>(file),
                (DayEnum.Day20, PartEnum.Part1) => new DayRunner<Day20Part1Solver>(file),
                (DayEnum.Day21, PartEnum.Part1) => new DayRunner<Day21Part1Solver>(file),
                (DayEnum.Day22, PartEnum.Part1) => new DayRunner<Day22Part1Solver>(file),
                (DayEnum.Day23, PartEnum.Part1) => new DayRunner<Day23Part1Solver>(file),
                (DayEnum.Day24, PartEnum.Part1) => new DayRunner<Day24Part1Solver>(file),
                (DayEnum.Day25, PartEnum.Part1) => new DayRunner<Day25Part1Solver>(file),

                (DayEnum.Day1, PartEnum.Part2) => new DayRunner<Day1Part2Solver>(file),
                (DayEnum.Day2, PartEnum.Part2) => new DayRunner<Day2Part2Solver>(file),
                (DayEnum.Day3, PartEnum.Part2) => new DayRunner<Day3Part2Solver>(file),
                (DayEnum.Day4, PartEnum.Part2) => new DayRunner<Day4Part2Solver>(file),
                (DayEnum.Day5, PartEnum.Part2) => new DayRunner<Day5Part2Solver>(file),
                (DayEnum.Day6, PartEnum.Part2) => new DayRunner<Day6Part2Solver>(file),
                (DayEnum.Day7, PartEnum.Part2) => new DayRunner<Day7Part2Solver>(file),
                (DayEnum.Day8, PartEnum.Part2) => new DayRunner<Day8Part2Solver>(file),
                (DayEnum.Day9, PartEnum.Part2) => new DayRunner<Day9Part2Solver>(file),
                (DayEnum.Day10, PartEnum.Part2) => new DayRunner<Day10Part2Solver>(file),
                (DayEnum.Day11, PartEnum.Part2) => new DayRunner<Day11Part2Solver>(file),
                (DayEnum.Day12, PartEnum.Part2) => new DayRunner<Day12Part2Solver>(file),
                (DayEnum.Day13, PartEnum.Part2) => new DayRunner<Day13Part2Solver>(file),
                (DayEnum.Day14, PartEnum.Part2) => new DayRunner<Day14Part2Solver>(file),
                (DayEnum.Day15, PartEnum.Part2) => new DayRunner<Day15Part2Solver>(file),
                (DayEnum.Day16, PartEnum.Part2) => new DayRunner<Day16Part2Solver>(file),
                (DayEnum.Day17, PartEnum.Part2) => new DayRunner<Day17Part2Solver>(file),
                (DayEnum.Day18, PartEnum.Part2) => new DayRunner<Day18Part2Solver>(file),
                (DayEnum.Day19, PartEnum.Part2) => new DayRunner<Day19Part2Solver>(file),
                (DayEnum.Day20, PartEnum.Part2) => new DayRunner<Day20Part2Solver>(file),
                (DayEnum.Day21, PartEnum.Part2) => new DayRunner<Day21Part2Solver>(file),
                (DayEnum.Day22, PartEnum.Part2) => new DayRunner<Day22Part2Solver>(file),
                (DayEnum.Day23, PartEnum.Part2) => new DayRunner<Day23Part2Solver>(file),
                (DayEnum.Day24, PartEnum.Part2) => new DayRunner<Day24Part2Solver>(file),
                (DayEnum.Day25, PartEnum.Part2) => new DayRunner<Day25Part2Solver>(file),
            };
        }
    }
}
