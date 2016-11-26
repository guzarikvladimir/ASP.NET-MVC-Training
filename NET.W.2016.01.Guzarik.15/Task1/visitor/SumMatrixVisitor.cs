using Task1.hierarchy;

namespace Task1.visitor
{
    /// <summary>
    /// Concrete class of visitor
    /// </summary>
    public class SumMatrixVisitor<T> : IMatrixVisitor<T>
    {
        /// <summary>
        /// Returns a matrix which is the result of sum of two matrexes
        /// </summary>
        public SquareMatrix<T> Sum { get; private set; }

        /// <summary>
        /// Returns a square matrix which is the result of sum of two square matrexes
        /// </summary>
        public void Visit(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
                for (var j = 0; j < result.Rank; j++)
                    result[i, j] += matrixB[i, j];

            Sum = result;
        }

        /// <summary>
        /// Returns a diagonal matrix which is the result of sum of two diagonal matrexes
        /// </summary>
        public void Visit(DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA.Clone();

            int i = 0, j = 0;
            foreach (var variable in matrixB)
                result[i++, j++] += variable;

            Sum = result;
        }

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of two symmetric matrexes
        /// </summary>
        public void Visit(SymmetricMatrix<T> matrixA, SymmetricMatrix<T> matrixB)
        {
            var result = (dynamic) matrixA.Clone();

            var length = 1;
            for (var i = 0; i < result.Rank; i++)
            {
                for (var j = 0; j < length; j++)
                    result[i, j] += matrixB[i, j];
                length++;
            }

            Sum = result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and diagonal matrexes
        /// </summary>
        public void Visit(SquareMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic) matrixA.Clone();

            int i = 0, j = 0;
            foreach (var variable in matrixB)
                result[i++, j++] += variable;

            Sum = result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and diagonal matrexes
        /// </summary>
        public void Visit(DiagonalMatrix<T> matrixA, SquareMatrix<T> matrixB) => Visit(matrixB, matrixA);

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and symmetric matrexes
        /// </summary>
        public void Visit(SquareMatrix<T> matrixA, SymmetricMatrix<T> matrixB)
        {
            var result = (dynamic) matrixA.Clone();

            for (var i = 0; i < result.Rank; i++)
                for (var j = 0; j < result.Rank; j++)
                    result[i, j] += matrixB[i, j];

            Sum = result;
        }

        /// <summary>
        /// Returns a square matrix which is the result of sum of square and symmetric matrexes
        /// </summary>
        public void Visit(SymmetricMatrix<T> matrixA, SquareMatrix<T> matrixB) => Visit(matrixB, matrixA);

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of symmetric and diagonal matrexes
        /// </summary>
        public void Visit(SymmetricMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var result = (dynamic)matrixA;

            int i = 0, j = 0;
            foreach (var variable in matrixB)
                result[i++, j++] += variable;

            Sum = result;
        }

        /// <summary>
        /// Returns a symmetric matrix which is the result of sum of symmetric and diagonal matrexes
        /// </summary>
        public void Visit(DiagonalMatrix<T> matrixA, SymmetricMatrix<T> matrixB) => Visit(matrixB, matrixA);
    }
}
