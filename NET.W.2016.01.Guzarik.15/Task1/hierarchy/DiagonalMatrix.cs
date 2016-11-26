using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.hierarchy
{
    /// <summary>
    /// Class represents a square diagonal matrix
    /// </summary>
    public sealed class DiagonalMatrix <T> : SquareMatrix<T>
    {
        private readonly T[] _matrix;

        #region Constructors

        /// <summary>
        /// Creates an empty diagonal matrix on specified rank (order)
        /// </summary>
        public DiagonalMatrix(int rank)
        {
            Rank = rank;
            _matrix = new T[rank];
        }

        /// <summary>
        /// Creates a diagonal matrix on specified collection of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements or when the matrix is not a diagonal</exception>
        public DiagonalMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            _matrix = new T[Rank];

            if (elements.Where((t, i) => i % (Rank + 1) != 0 && !Equals(t, elements[elements.Length - 1 - i])).Any())
                throw new ArgumentException("The matrix is not a diagonal");

            InitMatrix(elements);
        }

        /// <summary>
        /// Creates a diagonal matrix on specified collection of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements or when the matrix is not a diagonal</exception>
        public DiagonalMatrix(IEnumerable<T> elements) : this(elements.ToArray()) { }

        #endregion

        #region API

        /// <summary>
        /// Returns or sets value on specified index
        /// </summary>
        /// <remarks>Notifies about setting a value to the special element</remarks>
        /// <exception cref="ArgumentOutOfRangeException">Throws when indexes less than 0 or bigger than actual rank of matrix</exception>
        /// <exception cref="ArgumentException">Throws when try to set the value to non-diagonal element</exception>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                return i != j ? default(T) : _matrix[i];
            }
            set
            {
                if (i < 0 || i >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                if (i != j)
                    throw new ArgumentException("The indexes must be equal"); /* or create a new square matrix */
                
                OnIndexSetted($"Index [{i},{j}] has changed in diagonal matrix" + Environment.NewLine);

                _matrix[i] = value;
            }
        }

        /// <summary>
        /// Returns a deep copy of the diagonal matrix
        /// </summary>
        public new DiagonalMatrix<T> Clone()
        {
            var clone = new DiagonalMatrix<T>(Rank);

            for (var i = 0; i < Rank; i++)
                clone[i] = _matrix[i];

            return clone;
        }

        /// <summary>
        /// Iterates throug the diagonal matrix
        /// </summary>
        public override IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_matrix).GetEnumerator();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Allows to set a value to a diagonal element on only one index
        /// </summary>
        private T this[int i]
        {
            set { _matrix[i] = value; }
        }

        /// <summary>
        /// Initializes a diagonal matrix with specified collection of elements
        /// </summary>
        private void InitMatrix(IEnumerable<T> elements)
        {
            var tmp = elements.ToArray();

            var j = 0;
            for (var i = 0; i < tmp.Length; i++)
                if (i % (Rank + 1) == 0)
                    _matrix[j++] = tmp[i];
        }

        #endregion
    }
}
