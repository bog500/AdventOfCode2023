using AdventOfCode2023.Common;
using AdventOfCode2023.Day14;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day14Tests : DayBaseTests
    {
        public Day14Tests() : base(DayEnum.Day14)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 136)]
        [TestCase(FileEnum.Clue, 113078)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 64)]
        [TestCase(FileEnum.Clue, 94255)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}