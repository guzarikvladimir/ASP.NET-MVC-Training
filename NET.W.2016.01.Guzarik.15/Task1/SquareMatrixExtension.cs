using System;

namespace Task1
{
    /// <summary>
    /// Provides methods to work with different types of square matrix
    /// </summary>
    public static class SquareMatrixExtension
    {
        /// <summary>
        /// Returns sum of two matrix
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when matrixA or matrix B is null</exception>
        /// <exception cref="ArgumentException">Throws when ranks of matrix are different</exception>
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> matrixA, SquareMatrix<T> matrixB, Func<T, T, T> func)
        {
            if (ReferenceEquals(matrixA, null))
                throw new ArgumentNullException(nameof(matrixA));
            
            if (ReferenceEquals(matrixB, null))
                throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.Rank != matrixB.Rank)
                throw new ArgumentException("Ranks of matrix are different");

            var result = new SquareMatrix<T>(matrixA.Rank);

            for (var i = 0; i < matrixB.Rank; i++)
                for (var j = 0; j < matrixB.Rank; j++)
                    checked { result[i, j] = func(matrixA[i, j], matrixB[i, j]); }
            
            return result;
        }
    }
}
