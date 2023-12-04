using AdventOfCode2023.Common;
using AdventOfCode2023.Day3;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day3Tests : DayBaseTests<Day3Part1Solver, Day3Part2Solver>
    {
        public Day3Tests() : base(DayEnum.Day3)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 4361)]
        [TestCase(FileEnum.Clue, 536576)]
        public void Part1(FileEnum file, int expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo1, 467835)]
        [TestCase(FileEnum.Clue, 75741499)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}