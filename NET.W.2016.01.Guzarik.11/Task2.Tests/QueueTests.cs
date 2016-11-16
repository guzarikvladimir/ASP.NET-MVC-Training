using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class QueueTests
    {
        #region Constructors

        [TestCase(10, new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [TestCase(0, new int[0])]
        [TestCase(11, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void Constructor_NoPrametersEnqueueQueueNTimesAndToArrayTransformation_IntArrayEqualsToQueueToArray(int times, int[] expected)
        {
            // arrange
            var queue = new Queue<int>();

            // act
            for (var i = 0; i < times; i++)
            {
                queue.Enqueue(i);
            }
            var actual = queue.ToArray();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Constructor_ICollection_ColEqualsToQueueToArray()
        {
            // arrange
            var array = new[] {1, 2, 3, 4, 5};
            ICollection<int> col = array;

            // act
            var queue = new Queue<int>(col);

            // assert
            CollectionAssert.AreEqual(col, queue);
        }

        #endregion

        #region Methods

        [Test]
        public void Dequeue_DequeueBiggerTimesThanEnqueue_InvalidOperationException()
        {
            // arrange
            var queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            // act
            Assert.Catch<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 12; i++)
                {
                    queue.Dequeue();
                }
            });
        }

        [Test]
        public void Peek_PeekingNTimes_TheCountOfElementsInQueueDoesntChangeAndThePeeksSameElement()
        {
            // arrange
            var queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            // act/assert

            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(0, queue.Peek());
            }

            Assert.AreEqual(10, queue.Count);
        }

        [Test]
        public void CopyTo_OneDimentionalArray_Equals()
        {
            // arrange
            var queue = new Queue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            var actual = new string[2];

            // act
            queue.CopyTo(actual, 0);

            // assert
            Assert.AreEqual(queue, actual);
        }

        [Test]
        public void Clear_()
        {
            // arrange
            var queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            // act
            queue.Clear();

            // assert
            Assert.AreEqual(0, queue.Count);
        }

        #endregion
    }
}
