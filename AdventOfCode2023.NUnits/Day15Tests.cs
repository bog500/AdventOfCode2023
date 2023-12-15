using AdventOfCode2023.Common;
using AdventOfCode2023.Day15;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day15Tests : DayBaseTests
    {
        public Day15Tests() : base(DayEnum.Day15)
        {

        }

        [Test]
        [TestCase("HASH", 52)]
        [TestCase("rn=1", 30)]
        [TestCase("cm-", 253)]
        [TestCase("qp=3", 97)]
        [TestCase("cm=2", 47)]
        [TestCase("qp-", 14)]
        public void Hash(string str, long expected)
        {
            Day15Part1Solver solver = (Day15Part1Solver)part1Solver;
            long actual = solver.Hash(str);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(FileEnum.Demo1, 1320)]
        [TestCase(FileEnum.Clue, 521341)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo2, 145)]
        //[TestCase(FileEnum.Clue, 94255)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}