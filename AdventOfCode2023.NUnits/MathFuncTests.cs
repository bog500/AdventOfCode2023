using AdventOfCode2023.Common;
using AdventOfCode2023.Day1;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.NUnits
{
    public class MathFuncTests
    {
        public MathFuncTests()
        {

        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new long[] { 2, 3 }, 6)]
        [TestCase(new long[] { 10, 10 }, 10)]
        [TestCase(new long[] { 10, 10, 20 }, 20)]
        public void LeastCommonMultiple(long[] numbers, long expected)
        {
            long actual = MathFunc.LeastCommonMultiple(numbers);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(6, 9, 3)]
        [TestCase(15, 20, 5)]
        [TestCase(12, 24, 12)]
        public void GreatestCommonFactor(long a, long b, long expected)
        {
            long actual = MathFunc.GreatestCommonFactor(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}