using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.hierarchy
{
    /// <summary>
    /// Class represents a square symmetric matrix
    /// </summary>
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        private readonly T[][] _matrix;

        #region Constructors

        /// <summary>
        /// Creates an empty symmetric matrix on specified rank (order)
        /// </summary>
        public SymmetricMatrix(int rank)
        {
            Rank = rank;
            _matrix = new T[Rank][];

            for (var i = 0; i < Rank; i++)
                _matrix[i] = new T[i + 1];
        }

        /// <summary>
        /// Creates a symmetric matrix on specified collection of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements or when the matrix is not a symmetric</exception>
        public SymmetricMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            _matrix = new T[Rank][];

            for (var i = 0; i < Rank; i++)
                _matrix[i] = new T[i + 1];

            InitMatrix(elements);
        }

        /// <summary>
        /// Creates a symmetric matrix on specified collection of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements or when the matrix is not a symmetric</exception>
        public SymmetricMatrix(IEnumerable<T> elements) : this(elements.ToArray()) { }

        #endregion

        #region API

        /// <summary>
        /// Returns or sets value on specified index
        /// </summary>
        /// <remarks>Notifies about setting a value to the special element</remarks>
        /// <exception cref="ArgumentOutOfRangeException">Throws when indexes less than 0 or bigger than actual rank of matrix</exception>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                if (i >= j) return _matrix[i][j];

                var tmp = i;
                i = j;
                j = tmp;

                return _matrix[i][j];
            }
            set
            {
                if (i < 0 || i >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= Rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                OnIndexSetted($"Index [{i},{j}] has changed in symmetric matrix" + Environment.NewLine);

                if (i < j)
                {
                    var tmp = i;
                    i = j;
                    j = tmp;
                }

                _matrix[i][j] = value;
            }
        }

        /// <summary>
        /// Returns a deep copy of the symmetric matrix
        /// </summary>
        public new SymmetricMatrix<T> Clone()
        {
            var clone = new SymmetricMatrix<T>(Rank);

            var length = 1;
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < length; j++)
                    clone[i, j] = _matrix[i][j];
                length++;
            }

            return clone;
        }

        /// <summary>
        /// Iterates throug the symmetric matrix
        /// </summary>
        public override IEnumerator<T> GetEnumerator()
        {
            var length = 1;
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < length; j++)
                    yield return _matrix[i][j];
                length++;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a symmetric matrix with specified collection of elements
        /// </summary>
        private void InitMatrix(IEnumerable<T> elements)
        {
            var tmp = elements.ToArray();

            var length = 1;
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < length; j++)
                    _matrix[i][j] = tmp[i * Rank + j];
                length++;
            }

        }

        #endregion
    }
}
