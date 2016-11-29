using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Dictates the rules for different types of square matrexes
    /// </summary>
    public abstract class AbstractSquareMatrix<T>
    {
        private int _rank;

        /// <summary>
        /// Returns an info about changing the value of the element
        /// </summary>
        public IndexSettedEventArgs EventInfo { get; private set; }

        /// <summary>
        /// Returns or sets a rank of matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when rank less than 2</exception>
        public int Rank
        {
            get { return _rank; }
            protected set
            {
                if (value < 2)
                    throw new ArgumentException("The matrix connot have rank less than 2");

                _rank = value;
            }
        }

        /// <summary>
        /// Registers derivatives matrexes on the event
        /// </summary>
        protected AbstractSquareMatrix()
        {
            if (ReferenceEquals(IndexSetted, null))
                IndexSetted += ActWhenIndexSetted;
        }

        /// <summary>
        /// Returns or sets value on specified index
        /// </summary>
        /// <remarks>Notifies about setting a value to the special element</remarks>
        /// <exception cref="ArgumentOutOfRangeException">Throws when indexes less than 0 or bigger than actual rank of matrix</exception>
        public T this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);

                return GetIndexValue(i, j);
            }
            set
            {
                ValidateIndexes(i, j);

                OnIndexSetted(new IndexSettedEventArgs(i, j, this[i, j], value));

                SetIndexValue(i, j, value);
            }
        }

        /// <summary>
        /// Returns value by index
        /// </summary>
        protected abstract T GetIndexValue(int i, int j);

        /// <summary>
        /// Sets value by index
        /// </summary>
        protected abstract void SetIndexValue(int i, int j, T value);

        /// <summary>
        /// Colculates and returns the rank of square matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when the matrix is not a square</exception>
        protected static int TryGetRank(IEnumerable<T> elements)
        {
            var enumerable = elements as T[] ?? elements.ToArray();
            var rank = (int)Math.Sqrt(enumerable.Length);

            if (rank * rank != enumerable.Length)
                throw new ArgumentException("The matrix is not a square");

            return rank;
        }

        /// <summary>
        /// Iterates through the matrix
        /// </summary>
        public abstract IEnumerator<T> GetEnumerator();

        #region Event

        /// <summary>
        /// Event about changing the value of the element
        /// </summary>
        protected event EventHandler<IndexSettedEventArgs> IndexSetted;

        /// <summary>
        /// Occurs when index changes
        /// </summary>
        protected virtual void OnIndexSetted(IndexSettedEventArgs e)
        {
            IndexSetted?.Invoke(this, e);
        }

        /// <summary>
        /// Responds to the occurrence of events
        /// </summary>
        protected virtual void ActWhenIndexSetted(object sender, IndexSettedEventArgs e)
        {
            EventInfo = e;
        }

        /// <summary>
        /// Stores an info about changing the value of the element
        /// </summary>
        public sealed class IndexSettedEventArgs : EventArgs
        {
            /// <summary>
            /// First index of an element
            /// </summary>
            public int IndexI { get; private set; }
            /// <summary>
            /// Second index of an element
            /// </summary>
            public int IndexJ { get; private set; }
            /// <summary>
            /// The value before changing
            /// </summary>
            public T PreviousValue { get; private set; }
            /// <summary>
            /// The value after changing
            /// </summary>
            public T NewValue { get; private set; }

            /// <summary>
            /// Creates an info object, that keeps info about changing a value of an element on the index
            /// </summary>
            public IndexSettedEventArgs(int i, int j, T previousValue, T newValue)
            {
                IndexI = i;
                IndexJ = j;
                PreviousValue = previousValue;
                NewValue = newValue;
            }
        }

        #endregion

        #region Private Methods

        private void ValidateIndexes(int i, int j)
        {
            if (i < 0 || i >= _rank)
                throw new ArgumentOutOfRangeException(nameof(i));

            if (j < 0 || j >= _rank)
                throw new ArgumentOutOfRangeException(nameof(j));
        }

        #endregion
    }
}