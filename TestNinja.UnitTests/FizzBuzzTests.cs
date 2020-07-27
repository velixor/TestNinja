using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_MultipleOf3And5_ReturnBuzz()
        {
            var answer = FizzBuzz.GetOutput(15);
            
            Assert.That(answer, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_MultipleOf3Only_ReturnFizz()
        {
            var answer = FizzBuzz.GetOutput(3);
            
            Assert.That(answer, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_MultipleOf5Only_ReturnBuzz()
        {
            var answer = FizzBuzz.GetOutput(5);
            
            Assert.That(answer, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NotMultipleOf3Or5_ReturnNumber()
        {
            var answer = FizzBuzz.GetOutput(1);
            
            Assert.That(answer, Is.EqualTo("1"));
        }
    }
}