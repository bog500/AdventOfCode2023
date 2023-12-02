using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day2Tests : DayBaseTests<Day2Part1Solver, Day2Part2Solver>
    {
        public Day2Tests() : base(DayEnum.Day2)
        {

        }

        [Test]
        [TestCase(FileEnum.Demo1, 8)]
        [TestCase(FileEnum.Clue, 2169)]
        public void Part1(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            string actual = part1Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }

        [Test]
        [TestCase(FileEnum.Demo2, 2286)]
        [TestCase(FileEnum.Clue, 60948)]
        public void Part2(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            string actual = part2Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }
    }
}