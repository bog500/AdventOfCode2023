using AdventOfCode2023.Common;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day10Tests : DayBaseTests
    {
        public Day10Tests() : base(DayEnum.Day10)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 4)]
        [TestCase(FileEnum.Clue, 6890)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 4)]
        [TestCase(FileEnum.Demo3, 8)]
        [TestCase(FileEnum.Demo4, 10)]
        [TestCase(FileEnum.Clue, 1154)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}