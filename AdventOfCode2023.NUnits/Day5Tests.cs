using AdventOfCode2023.Common;
using AdventOfCode2023.Day5;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day5Tests : DayBaseTests
    {
        public Day5Tests() : base(DayEnum.Day4)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 0)]
        [TestCase(FileEnum.Clue, 0)]
        public void Part1(FileEnum file, int expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo1, 0)]
        [TestCase(FileEnum.Clue, 0)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}