using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Class represents a square matrix
    /// </summary>
    public class SquareMatrix<T> : AbstractSquareMatrix<T>, ICloneable
    {
        private readonly T[] _matrix;

        /// <summary>
        /// Creates an empty square matrix on specified rank (order)
        /// </summary>
        public SquareMatrix(int rank)
        {
            Rank = rank;
            _matrix = new T[Rank*Rank];
        }

        /// <summary>
        /// Creates a square matrix on specified collection of elements with event registration
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements</exception>
        public SquareMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            _matrix = new T[Rank*Rank];
            Array.Copy(elements, _matrix, elements.Length);
        }

        /// <summary>
        /// Returns value by index
        /// </summary>
        protected override T GetIndexValue(int i, int j)
        {
            return _matrix[i*Rank + j];
        }

        /// <summary>
        /// Sets value by index
        /// </summary>
        protected override void SetIndexValue(int i, int j, T value)
        {
            _matrix[i*Rank + j] = value;
        }

        /// <summary>
        /// Iterates throug the square matrix
        /// </summary>
        public override IEnumerator<T> GetEnumerator()
        {
            return _matrix.Cast<T>().GetEnumerator();
        }

        /// <summary>
        /// Returns a deep copy of the symmetric matrix
        /// </summary>
        public SquareMatrix<T> Clone()
        {
            return new SquareMatrix<T>(_matrix);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
