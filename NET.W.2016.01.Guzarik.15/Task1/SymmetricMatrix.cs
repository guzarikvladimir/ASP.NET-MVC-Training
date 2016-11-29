using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Class represents a square symmetric matrix
    /// </summary>
    public sealed class SymmetricMatrix<T> : AbstractSquareMatrix<T>, ICloneable
    {
        private readonly T[] _matrix;

        /// <summary>
        /// Creates an empty symmetric matrix on specified rank (order)
        /// </summary>
        public SymmetricMatrix(int rank)
        {
            Rank = rank;
            _matrix = new T[LastRowIndex(Rank)];
        }

        /// <summary>
        /// Creates a symmetric matrix on specified collection of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements or when the matrix is not a symmetric</exception>
        public SymmetricMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            _matrix = new T[LastRowIndex(Rank)];

            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    if (!Equals(elements[i * Rank + j], elements[j * Rank + i]))
                    {
                        throw new ArgumentException("The matrix is not a symmetric");
                    }
                }
            }
            InitMatrix(elements);
        }

        /// <summary>
        /// Returns value by index
        /// </summary>
        protected override T GetIndexValue(int i, int j)
        {
            return j > i ? _matrix[LastRowIndex(j) + i] : 
                _matrix[LastRowIndex(i) + j];
        }

        /// <summary>
        /// Sets value by index
        /// </summary>
        /// <exception cref="ArgumentException">Throws when indexes are not equal</exception>
        protected override void SetIndexValue(int i, int j, T value)
        {
            if (j > i)
                _matrix[LastRowIndex(j) + i] = value;
            else
                _matrix[LastRowIndex(i) + j] = value;
        }

        /// <summary>
        /// Iterates throug the symmetric matrix
        /// </summary>
        public override IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    yield return j > i ? this[j, i] : this[i, j];
                }
            }
        }

        /// <summary>
        /// Initializes a symmetric matrix with specified collection of elements
        /// </summary>
        private void InitMatrix(IEnumerable<T> elements)
        {
            var tmp = elements.ToArray();

            var length = 1;
            var count = 0;
            for (var i = 0; i < Rank; i++, length++)
            {
                for (var j = 0; j < length; j++)
                    _matrix[count++] = tmp[i * Rank + j];
            }

        }

        /// <summary>
        /// Returns a deep copy of the symmetric matrix
        /// </summary>
        public SymmetricMatrix<T> Clone()
        {
            var clone = new SymmetricMatrix<T>(Rank);
            Array.Copy(_matrix, clone._matrix, _matrix.Length);
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private int LastRowIndex(int index)
        {
            var result = 0;
            for (var i = 0; i < index; i++)
            {
                result += i + 1;
            }

            return result;
        }
    }
}
