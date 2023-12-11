using AdventOfCode2023.Common;
using AdventOfCode2023.Day11;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day11Tests : DayBaseTests
    {
        public Day11Tests() : base(DayEnum.Day11)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 374)]
        [TestCase(FileEnum.Clue, 10033566)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 10, 1030)]
        [TestCase(FileEnum.Demo2, 100, 8410)]
        [TestCase(FileEnum.Demo2, 1000000, 82000210)]
        [TestCase(FileEnum.Clue, 1000000, 560822911938)]
        public void Part2(FileEnum file, int expand, long expected)
        {
            ((Day11Part2Solver)base.part2Solver).Expand(expand);
            base.Part2(file, expected.ToString());
        }
    }
}