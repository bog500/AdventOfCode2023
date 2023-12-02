using AdventOfCode2023.Common;
using AdventOfCode2023.Day1;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day1Tests : DayBaseTests<Day1Part1Solver, Day1Part2Solver>
    {
        public Day1Tests() : base(DayEnum.Day1)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 142)]
        [TestCase(FileEnum.Clue, 55447)]
        public void Part1(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            string actual = part1Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }

        [Test]
        [TestCase(FileEnum.Demo2, 281)]
        [TestCase(FileEnum.Clue, 54706)]
        public void Part2(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            string actual = part2Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }
    }
}