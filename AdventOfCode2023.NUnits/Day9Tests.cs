using AdventOfCode2023.Common;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day9Tests : DayBaseTests
    {
        public Day9Tests() : base(DayEnum.Day9)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 0)]
        [TestCase(FileEnum.Clue, 0)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 0)]
        [TestCase(FileEnum.Clue, 0)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}