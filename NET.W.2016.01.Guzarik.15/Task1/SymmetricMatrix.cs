using System;

namespace Task1
{
    /// <summary>
    /// Class represents symmetric square matrix
    /// </summary>
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Creates a symmetric square matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when elements, are not symmetric on diagonal or when matrix cannot be a square with such amount of elements</exception>
        public SymmetricMatrix(params T[] elements) : base(elements)
        {
            for (var i = 0; i < Rank; i++)
                for (var j = 0; j < Rank; j++)
                {
                    if (i == j) continue;

                    if (!Equals(Matrix[i, j], Matrix[j, i]))
                        throw new ArgumentException("The matrix is not a symmetric");
                }
        }
    }
}