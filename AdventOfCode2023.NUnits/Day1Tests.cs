using AdventOfCode2023.Common;
using AdventOfCode2023.Day01;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day1Tests
    {
        private Part1Solver part1Solver;
        private Part2Solver part2Solver;
        private ClueReader cr;

        [SetUp]
        public void Setup()
        {
            part1Solver = new Part1Solver();
            part2Solver = new Part2Solver();
            cr = new ClueReader(DayEnum.Day1);
        }


        [Test]
        [TestCase(FileEnum.Demo1, 142)]
        [TestCase(FileEnum.Clue, 55447)]
        public void Part1(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            int actual = part1Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(FileEnum.Demo2, 281)]
        [TestCase(FileEnum.Clue, 54706)]
        public void Part2(FileEnum file, int expected)
        {
            List<string> lines = cr.Read(file);

            int actual = part2Solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}