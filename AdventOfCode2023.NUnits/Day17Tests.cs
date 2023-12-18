using AdventOfCode2023.Common;
using AdventOfCode2023.Day17;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day17Tests : DayBaseTests
    {
        public Day17Tests() : base(DayEnum.Day17)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 102)]
        [TestCase(FileEnum.Clue, 7496)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 51)]
        [TestCase(FileEnum.Clue, 7932)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}