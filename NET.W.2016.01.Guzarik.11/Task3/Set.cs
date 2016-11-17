using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    /// <summary>
    /// Represents a set of reference values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Set<T> : IEnumerable<T> where T : class
    {
        private T[] _collection;
        private readonly IEqualityComparer<T> _comparer;
        private int _last;
        private readonly int _defCapacity = 10;
        private readonly float _growFactory = 1.5f;

        /// <summary>
        /// Gets the number of elements that are contained in a set
        /// </summary>
        public int Count => _last;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Set class that is empty and uses the default equality comparer for the set type.
        /// </summary>
        public Set() : this(new DefaultComparer()) { }

        /// <summary>
        /// Initializes a new instance of the Set class that is empty and uses the specified equality comparer for the set type.
        /// </summary>
        public Set(IEqualityComparer<T> comparer)
        {
            _comparer = comparer;
            _collection = new T[_defCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the Set class that uses the default equality comparer for the set type, contains elements copied from the specified collection, and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        public Set(IEnumerable<T> collection) : this(collection, new DefaultComparer()) { }

        /// <summary>
        /// Initializes a new instance of the Set class that uses the specified equality comparer for the set type, contains elements copied from the specified collection, and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <exception cref="ArgumentNullException">Collection is empty</exception>
        public Set(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _comparer = comparer;
            _collection = new T[collection.Count()];

            foreach (var variable in collection)
            {
                Add(variable);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified element to a Set object
        /// </summary>
        public void Add(T elem)
        {
            if (_last == _collection.Length)
            {
                var capacity = (int)(_collection.Length * _growFactory);
                var newCollection = new T[capacity];
                Array.Copy(_collection, newCollection, _last);
                _collection = newCollection;
            }
            if (IndexOf(elem) != -1) return;

            _collection[_last++] = elem;
        }

        /// <summary>
        /// Removes the specified element from a Set object
        /// </summary>
        /// <exception cref="ArgumentException">The element doesn't contained in a Set object</exception>
        public void Remove(T elem)
        {
            var index = IndexOf(elem);

            if (index == -1)
            {
                throw new ArgumentException(nameof(elem));
            }

            for (var j = index; j < _last - 1; j++)
            {
                _collection[j] = _collection[j + 1];
            }

            _collection[_last--] = default(T);
        }

        /// <summary>
        /// Copies the elements of Set object to an array
        /// </summary>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        public void CopyTo(T[] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array.Copy(_collection, array, _last);
        }

        /// <summary>
        /// Determines whether a Set object contains the specified element
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool Contains(T elem)
        {
            return IndexOf(elem) != -1;
        }

        /// <summary>
        /// Sets the capacity of a Set object  to the actual number of elements it contains
        /// </summary>
        public void TrimToSize()
        {
            var newCollection = new T[_last];
            Array.Copy(_collection, newCollection, _last);
            _collection = newCollection;
        }

        /// <summary>
        /// Removes all elements from a Set object 
        /// </summary>
        public void Clear()
        {
            Array.Clear(_collection, 0, _last);
            _last = 0;
        }

        /// <summary>
        /// Returns the index of specified element
        /// </summary>
        public int IndexOf(T elem)
        {
            for (var i = 0; i < _last; i++)
            {
                if (_comparer.Equals(elem, _collection[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        /// <summary>
        /// Allows instance of a set class to be indexed just like arrays
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Index less than 0 or bigger than the number of elements in a set object</exception>
        public T this[int index ]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _collection[index];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a Set object
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _last; i++)
            {
                yield return _collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DefaultComparer : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                if (ReferenceEquals(x, null))
                {
                    throw new ArgumentNullException();
                }

                if (ReferenceEquals(y, null))
                {
                    throw new ArgumentNullException();
                }

                return Equals(x.GetHashCode(), y.GetHashCode());
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
