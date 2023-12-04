using AdventOfCode2023.Common;
using AdventOfCode2023.Day1;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day1Tests : DayBaseTests
    {
        public Day1Tests() : base(DayEnum.Day1)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 142)]
        [TestCase(FileEnum.Clue, 55447)]
        public void Part1(FileEnum file, int expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 281)]
        [TestCase(FileEnum.Clue, 54706)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}