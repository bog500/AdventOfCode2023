using AdventOfCode2023.Common;
using AdventOfCode2023.Day5;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day5Tests : DayBaseTests
    {
        public Day5Tests() : base(DayEnum.Day5)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 35)]
        [TestCase(FileEnum.Clue, 340994526)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo1, 46)]
        // read is not foundyet
        //[TestCase(FileEnum.Clue, 0)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}