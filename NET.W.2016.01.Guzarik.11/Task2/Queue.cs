using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Generic queue
    /// </summary>
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _collection;
        private int _head;
        private int _tail;
        private int _capacity;
        private readonly int _defaultCapacity = 10;
        private readonly float _growFactory = 1.5f;

        /// <summary>
        /// Returns actual count of elements in Queue
        /// </summary>
        public int Count => _collection.Length;

        #region Constructors

        /// <summary>
        /// Initializes a new Queue with default capacity and grow factory
        /// </summary>
        public Queue()
        {
            _collection = new T[_defaultCapacity];
            _capacity = _defaultCapacity;
        }

        /// <summary>
        /// Initializes a new Queue with mentioned capacity and default grow factory
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Capacity is lower then 0</exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _collection = new T[capacity];
            _capacity = capacity;
        }

        /// <summary>
        /// Initializes a new Queue with mentioned capacity and grow factory
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Capacity is lower then 0 or growFactory less then 1.0 or bigger then 10.0</exception>
        public Queue(int capacity, float growFactory)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            if (growFactory < 1.0f || growFactory > 10.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(growFactory));
            }

            _collection = new T[capacity];
            _growFactory = growFactory;
            _capacity = capacity;
        }

        /// <summary>
        /// Initializes a new Queue with elements from the col. The capacity of queue is equal to the number of elements in col. Grow factory is default
        /// </summary>
        /// <exception cref="ArgumentNullException">Col is null</exception>
        public Queue(ICollection<T> col)
        {
            if (ReferenceEquals(col, null))
            {
                throw new ArgumentNullException(nameof(col));
            }

            _collection = new T[col.Count];
            _capacity = _collection.Length;
            foreach (var variable in col)
            {
                Enqueue(variable);
            }
        }

        /// <summary>
        /// Returns a new copy of Queue
        /// </summary>
        /// <exception cref="ArgumentNullException">Input Queue is null</exception>
        public Queue(Queue<T> queue)
        {
            if (ReferenceEquals(queue, null))
            {
                throw new ArgumentNullException();
            }

            _collection = new T[queue.Count];
            Array.Copy(queue._collection, _collection, queue.Count);
        }

        #endregion

        #region Methods for work

        /// <summary>
        /// Adds an element in the end of Queue
        /// </summary>
        public void Enqueue(T elem)
        {
            if (Equals(_collection.Length, _capacity))
            {
                var newCollection = new T[(int)(_capacity*_growFactory)];
                Array.Copy(_collection, newCollection, _collection.Length);
                _collection = newCollection;
                _capacity = (int)(_capacity * _growFactory);
            }
            _collection[_tail++%_capacity] = elem;
        }

        /// <summary>
        /// Returns and removes the first element of Queue
        /// </summary>
        /// <exception cref="InvalidOperationException">The Queue is empty</exception>
        public T Dequeue()
        {
            if (_collection.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _collection[++_head%_capacity];
        }

        /// <summary>
        /// Returns the first element in Queue without removing
        /// </summary>
        /// <exception cref="InvalidOperationException">The Queue is empty</exception>
        public T Peek()
        {
            if (_collection.Length == 0)
            {
                throw new InvalidOperationException(nameof(Queue<T>));
            }

            return _collection[_head];
        }

        /// <summary>
        /// Copies the elements of Queue in one-dimantional array, beginning with mentioned index
        /// </summary>
        /// <param name="array">One-dimentional array</param>
        /// <param name="index">index (from 0) in array, at which copyimg begins</param>
        /// <exception cref="ArgumentOutOfRangeException">The index is out of range</exception>
        /// <exception cref="ArgumentNullException">Input array is null</exception>
        /// <exception cref="ArgumentException">Array is not a one-dimentioanal</exception>
        /// <exception cref="ArrayTypeMismatchException">Can't automatically cast type of Queue to type of array</exception>
        public void CopyTo(Array array, int index)
        {
            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetType().GetArrayRank() != 1)
            {
                throw new ArgumentException("Array is not a one-dimentioanal");
            }

            if (array.GetType() != typeof(T))
            {
                throw new ArrayTypeMismatchException(nameof(array));
            }

            Array.Copy(_collection, 0, array, index, _collection.Length - index);
        }

        /// <summary>
        /// Sets the caacity equals to actual number of elements in Queue
        /// </summary>
        public void TrimToSize()
        {
            var newCollection = new T[_collection.Length];
            Array.Copy(_collection, newCollection, _collection.Length);
            _collection = newCollection;
            _capacity = _collection.Length;
        }

        /// <summary>
        ///Removes all elements from Queue
        /// </summary>
        public void Clear()
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                _collection[i] = default(T);
            }
        }

        #endregion

        #region Enumerator

        /// <summary>
        /// Returns enumerator that iterates through the collection
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Incapsuates the enumarator of generic Queue
        /// </summary>
        public struct QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> _queue;
            private int _current; 

            internal QueueEnumerator(Queue<T> queue)
            {
                _queue = queue;
                _current = -1;
            }

            /// <summary>
            /// Moves to next element
            /// </summary>
            public bool MoveNext()
            {
                return ++_current%_queue.Count < _queue.Count;
            }

            /// <summary>
            /// Resets position
            /// </summary>
            public void Reset()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns current element
            /// </summary>
            /// <exception cref="InvalidOperationException">Queue is over</exception>
            public T Current
            {
                get
                {
                    if (_current == -1 || _current == _queue.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return _queue._collection[_current%_queue.Count];
                }
            }

            /// <summary>
            /// Releases managed resources
            /// </summary>
            public void Dispose() { }

            object IEnumerator.Current => Current;
        }

        #endregion
    }
}
