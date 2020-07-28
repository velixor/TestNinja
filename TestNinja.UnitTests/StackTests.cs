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
        public void Push_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_PopSameElement()
        {
            _stack.Push("abc");

            Assert.That(_stack.Pop(), Is.EqualTo("abc"));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_StackWithTwoElement_ReturnTwo()
        {
            _stack.Push("one");
            _stack.Push("two");

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.TypeOf<InvalidOperationException>());
        }


        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Pop(), Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithFewObjects_RemoveObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Peek(), Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithFewObjects_DoesNotRemoveObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}