using AdventOfCode2023.Common;
using AdventOfCode2023.Day4;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day4Tests : DayBaseTests
    {
        public Day4Tests() : base(DayEnum.Day4)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 13)]
        [TestCase(FileEnum.Clue, 32001)]
        public void Part1(FileEnum file, int expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo1, 30)]
        [TestCase(FileEnum.Clue, 5037841)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}