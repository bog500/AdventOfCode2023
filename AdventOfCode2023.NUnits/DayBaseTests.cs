using AdventOfCode2023.Common;
using AdventOfCode2023.Day1;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public abstract class DayBaseTests(DayEnum day)
    {
        protected IPartSolver part1Solver;
        protected IPartSolver part2Solver;
        protected ClueReader cr;

        [SetUp]
        public void Setup()
        {
            IDayRunner runner1 = DayRunners.Get(day, PartEnum.Part1);
            IDayRunner runner2 = DayRunners.Get(day, PartEnum.Part2);

            part1Solver = runner1.GetSolver();
            part2Solver = runner2.GetSolver();
            cr = new ClueReader(day);
        }

        public void Part1(FileEnum file, string expected)
        {
            AssertTest(part1Solver, file, expected);
        }

        public void Part2(FileEnum file, string expected)
        {
            AssertTest(part2Solver, file, expected);
        }

        private void AssertTest(IPartSolver solver, FileEnum file, string expected)
        {
            List<string> lines = cr.Read(file);

            string actual = solver.Solve(lines);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}