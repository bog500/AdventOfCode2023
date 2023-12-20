using AdventOfCode2023.Common;
using AdventOfCode2023.Day19;
using AdventOfCode2023.Day6;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class Day19Tests : DayBaseTests
    {
        public Day19Tests() : base(DayEnum.Day19)
        {

        }


        [Test]
        [TestCase("{x=787,m=2655,a=1222,s=2876}", 787, 2655, 1222, 2876)]
        [TestCase("{x=-787,m=-2655,a=-1222,s=-2876}", -787, -2655, -1222, -2876)]
        [TestCase("{x=787 ,  m=2655  ,a=1222,s =  2876}", 787, 2655, 1222, 2876)]
        public void ParseData(string str, int x, int m, int a, int s)
        {
            var solver = (Day19BaseSolver)part1Solver;
            var data = solver.ParseData(str);

            Assert.That(data.X == x);
            Assert.That(data.M == m);
            Assert.That(data.A == a);
            Assert.That(data.S == s);
        }

        [Test]
        [TestCase("ex{x>10:one,m<20:two,a>30:R,A}", "ex", "A", 3)]
        [TestCase("exxx{x>10:one,R}", "exxx", "R", 1)]
        public void ParseRuleSet(string str, string key, string target, int nbRules)
        {
            var solver = (Day19BaseSolver)part1Solver;
            var ruleset = solver.ParseRuleSet(str);

            Assert.That(ruleset.Key == key);
            Assert.That(ruleset.TargetKey == target);
            Assert.That(ruleset.Rules.Count == nbRules);
        }

        [Test]
        [TestCase("x>10:one", 'x', true, "one")]
        [TestCase("m<10:rrr", 'm', false, "rrr")]
        public void ParseRule(string str, char c, bool isGreater, string target)
        {
            var solver = (Day19BaseSolver)part1Solver;
            var rule = solver.ParseRule(str);

            Assert.That(rule.Chr == c);
            Assert.That(rule.IsGreater == isGreater);
            Assert.That(rule.TargetKey == target);
        }

        [Test]
        [TestCase(FileEnum.Demo1, 19114)]
        //[TestCase(FileEnum.Clue, 26857)]
        public void Part1(FileEnum file, long expected)
        {
            base.Part1(file, expected.ToString());
        }

        //[Test]
        //[TestCase(FileEnum.Demo2, 51)]
        //[TestCase(FileEnum.Clue, 7932)]
        public void Part2(FileEnum file, int expected)
        {
            base.Part2(file, expected.ToString());
        }
    }
}