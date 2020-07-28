using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void PushNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void PushElement_PopSameElement()
        {
            _stack.Push("abc");

            Assert.That(_stack.Count, Is.EqualTo(1));
            Assert.That(_stack.Pop(), Is.EqualTo("abc"));
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
            Assert.That(() => _stack.Pop(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void PushElement_PeekSameElement()
        {
            _stack.Push("abc");

            Assert.That(_stack.Peek(), Is.EqualTo("abc"));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
            Assert.That(() => _stack.Peek(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}