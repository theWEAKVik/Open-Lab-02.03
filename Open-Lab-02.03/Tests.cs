using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_02._03
{
    [TestFixture]
    public class Tests
    {

        private Calculator calculator;

        private const int RandSeed = 1235789;
        private const int RandTestCasesCount = 95;

        [OneTimeSetUp]
        public void Init() => calculator = new Calculator();

        [TestCase(1, 3, 1)]
        [TestCase(3, 4, 3)]
        [TestCase(25, 5, 0)]
        [TestCase(100, 6, 4)]
        [TestCase(-9, 15, -9)]
        [TestCaseSource(nameof(GetRandom))]
        public void Remainder(int dividend, int divisor, int quotient) =>
            Assert.AreEqual(quotient, calculator.Remainder(dividend, divisor));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var dividend = random.Next();
                var divisor = random.Next(dividend);
                yield return new TestCaseData(dividend, divisor, dividend % divisor);
            }
        }

    }
}
