using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Class represents a square diagonal matrix
    /// </summary>
    public sealed class DiagonalMatrix <T> : AbstractSquareMatrix<T>, ICloneable
    {
        private readonly T[] _matrix;

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
        /// Returns value by index
        /// </summary>
        protected override T GetIndexValue(int i, int j)
        {
            return i != j ? default(T) : _matrix[i];
        }

        /// <summary>
        /// Sets value by index
        /// </summary>
        /// <exception cref="ArgumentException">Throws when indexes are not equal</exception>
        protected override void SetIndexValue(int i, int j, T value)
        {
            if (i != j)
                throw new ArgumentException("Indexes must be equal");

            _matrix[i] = value;
        }

        /// <summary>
        /// Iterates through the matrix
        /// </summary>
        public override IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    yield return i != j ? default(T) : _matrix[i];
                }
            }
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

        /// <summary>
        /// Returns a copy of the diagonal matrix object
        /// </summary>
        /// <returns></returns>
        public DiagonalMatrix<T> Clone()
        {
            var clone = new DiagonalMatrix<T>(Rank);
            Array.Copy(_matrix, clone._matrix, _matrix.Length);
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
