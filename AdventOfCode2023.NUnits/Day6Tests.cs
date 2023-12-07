using AdventOfCode2023.Common;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day6Tests : DayBaseTests
    {
        public Day6Tests() : base(DayEnum.Day6)
        {

        }

        [Test]
        [TestCase(0, 7, 9, 0)]
        [TestCase(1, 7, 9, 6)]
        [TestCase(2, 7, 9, 10)]
        [TestCase(3, 7, 9, 12)]
        [TestCase(4, 7, 9, 12)]
        [TestCase(5, 7, 9, 10)]
        [TestCase(6, 7, 9, 6)]
        [TestCase(7, 7, 9, 0)]
        public void CalcDistance(int buttonTime, int raceTime, long raceDistance, long expected)
        {
            Race race = new(raceTime, raceDistance);

            var actual = Day6Part1Solver.CalcDistance(buttonTime, race);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(7, 9, 4)]
        [TestCase(15, 40, 8)]
        [TestCase(30, 200, 9)]
        [TestCase(35937366, 212206012011044, 21039729)]
        public void NbWin(int raceTime, long raceDistance, int expected)
        {
            Race race = new(raceTime, raceDistance);

            var actual = Day6Part1Solver.CalcNbWin(race);

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(FileEnum.Demo1, 288)]
        [TestCase(FileEnum.Clue, 114400)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        [Test]
        [TestCase(FileEnum.Demo1, 71503)]
        [TestCase(FileEnum.Clue, 21039729)]
        public void Part2(FileEnum file, long expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}