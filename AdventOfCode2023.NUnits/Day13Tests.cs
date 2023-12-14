using AdventOfCode2023.Common;
using AdventOfCode2023.Day13;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day13Tests : DayBaseTests
    {
        public Day13Tests() : base(DayEnum.Day13)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 405)]
        [TestCase(FileEnum.Clue, 30487)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 400)]
        //[TestCase(FileEnum.Clue, 560822913938)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}