using System;

namespace Task1
{
    /// <summary>
    /// Provides extension methods for square matrix
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Returns a square matrix which is the result of two matrix's sum 
        /// </summary>
        /// <exception cref="ArgumentException">Throws when ranks of matrexes are defferent</exception>
        public static AbstractSquareMatrix<T> Sum<T>(this AbstractSquareMatrix<T> matrixA, AbstractSquareMatrix<T> matrixB)
        {
            if (matrixA.Rank != matrixB.Rank)
                throw new ArgumentException("Ranks of matrexes are different");

            return Sum((dynamic)matrixA, (dynamic)matrixB);
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of two square matrexes
        /// </summary>
        private static SquareMatrix<T> Sum<T>(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
            {
                for (var j = 0; j < result.Rank; j++)
                {
                    result[i, j] += matrixB[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a diagonal matrix which is the result of sum of two diagonal matrexes
        /// </summary>
        private static DiagonalMatrix<T> Sum<T>(DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            int i = 0, j = 0;
            for (; i < result.Rank; i++, j++)
            {
                result[i, j] += matrixB[i, j];
            }

            return result;
        }

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of two symmetric matrexes
        /// </summary>
        private static SymmetricMatrix<T> Sum<T>(SymmetricMatrix<T> matrixA, SymmetricMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
            {
                for (var j = 0; j < result.Rank; j++)
                {
                    result[i, j] += matrixB[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and diagonal matrexes
        /// </summary>
        private static SquareMatrix<T> Sum<T>(SquareMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
            {
                for (var j = 0; j < result.Rank; j++)
                {
                    result[i, j] += matrixB[i, j];
                }
            }
            
            return result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and diagonal matrexes
        /// </summary>
        private static SquareMatrix<T> Sum<T>(DiagonalMatrix<T> matrixA, SquareMatrix<T> matrixB) => Sum(matrixB, matrixA);

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and symmetric matrexes
        /// </summary>
        private static SquareMatrix<T> Sum<T>(SquareMatrix<T> matrixA, SymmetricMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
            {
                for (var j = 0; j < result.Rank; j++)
                {
                    result[i, j] += matrixB[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and symmetric matrexes
        /// </summary>
        private static SquareMatrix<T> Sum<T>(SymmetricMatrix<T> matrixA, SquareMatrix<T> matrixB) => Sum(matrixB, matrixA);

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of symmetric and diagonal matrexes
        /// </summary>
        private static SymmetricMatrix<T> Sum<T>(SymmetricMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA;

            var i = 0;
            foreach (var variable in matrixB)
            {
                result[i++, i] += variable;
            }

            return result;
        }

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of symmetric and diagonal matrexes
        /// </summary>
        private static SymmetricMatrix<T> Sum<T>(DiagonalMatrix<T> matrixA, SymmetricMatrix<T> matrixB) => Sum(matrixB, matrixA);
    }
}
