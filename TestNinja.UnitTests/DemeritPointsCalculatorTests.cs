using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        private DemeritPointsCalculator _demeritPointsCalculator;

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowException(int speed)
        {
            int CalculateDemeritPointsDelegate()
            {
                return _demeritPointsCalculator.CalculateDemeritPoints(speed);
            }

            Assert.That(CalculateDemeritPointsDelegate, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(65, 0)]
        [TestCase(70, 1)]
        [TestCase(79, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedPoints)
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(speed), Is.EqualTo(expectedPoints));
        }
    }
}