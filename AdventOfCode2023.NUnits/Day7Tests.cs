using AdventOfCode2023.Common;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day7Tests : DayBaseTests
    {
        public Day7Tests() : base(DayEnum.Day7)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 6440)]
        [TestCase(FileEnum.Clue, 252295678)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 5905)]
        [TestCase(FileEnum.Clue, 250577259)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}