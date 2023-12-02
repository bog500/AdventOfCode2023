using AdventOfCode2023.Common;
using AdventOfCode2023.Day1;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public abstract class DayBaseTests<T1, T2>(DayEnum day)
        where T1 : IPartSolver, new()
        where T2 : IPartSolver, new()
    {
        protected T1 part1Solver;
        protected T2 part2Solver;
        protected ClueReader cr;

        [SetUp]
        public void Setup()
        {
            part1Solver = new();
            part2Solver = new();
            cr = new ClueReader(day);
        }

    }
}