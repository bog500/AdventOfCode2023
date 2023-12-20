using AdventOfCode2023.Common;
using AdventOfCode2023.Day18;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day18Tests : DayBaseTests
    {
        public Day18Tests() : base(DayEnum.Day18)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 62)]
        [TestCase(FileEnum.Test1, 94)]
        [TestCase(FileEnum.Clue, 26857)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        //[Test]
        //[TestCase(FileEnum.Demo2, 51)]
        //[TestCase(FileEnum.Clue, 7932)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}