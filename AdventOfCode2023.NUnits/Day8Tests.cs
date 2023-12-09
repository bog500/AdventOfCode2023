using AdventOfCode2023.Common;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day87Tests : DayBaseTests
    {
        public Day87Tests() : base(DayEnum.Day8)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 2)]
        [TestCase(FileEnum.Clue, 14681)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 6)]
        [TestCase(FileEnum.Clue, 14321394058031)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}