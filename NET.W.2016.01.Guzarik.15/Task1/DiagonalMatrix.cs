using System;

namespace Task1
{
    /// <summary>
    /// Class represents diagonal square matrix
    /// </summary>
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Creates a diagonal square matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when elements, except diagonal, are not default or when matrix cannot be a square with such amount of elements</exception>
        public DiagonalMatrix(params T[] elements) : base(elements)
        {
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    if (i == j) continue;

                    if (!Equals(Matrix[i, j], default(T)))
                        throw new ArgumentException("The matrix is not a diagonal");
                }
            }
        }
    }
}
