using System;
using NUnit.Framework;
using _math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    public class MathTests
    {
        private _math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new _math();
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void Add_WhenCalled_ReturnSumOfArguments(int a, int b, int expectedResult)
        {
            var result = _math.Add(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumberUpToZero()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));
        }

        [Test]
        public void GetOddNumbers_LimitIsZero_ReturnsEmptyArray()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty);
        }
    }
}