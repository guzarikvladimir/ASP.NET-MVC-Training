using Task1.hierarchy;

namespace Task1.visitor
{
    /// <summary>
    /// Interface visitor that defines a Visit method for each object Square matrix
    /// </summary>
    public interface IMatrixVisitor<T>
    {
        /// <summary>
        /// Visits two square matrixes
        /// </summary>
        void Visit(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB);
        /// <summary>
        /// Visits two diagonal matrexes
        /// </summary>
        void Visit(DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB);
        /// <summary>
        /// Visits two symmetric matrexes
        /// </summary>
        void Visit(SymmetricMatrix<T> matrixA, SymmetricMatrix<T> matrixB);
        /// <summary>
        /// Visits square and diagonal matrix
        /// </summary>
        void Visit(SquareMatrix<T> matrixA, DiagonalMatrix<T> matrixB);
        /// <summary>
        /// Visits diagonal and square matrix
        /// </summary>
        void Visit(DiagonalMatrix<T> matrixA, SquareMatrix<T> matrixB);
        /// <summary>
        /// Visits square and symmetric matrix
        /// </summary>
        void Visit(SquareMatrix<T> matrixA, SymmetricMatrix<T> matrixB);
        /// <summary>
        /// Visits symmetric and square matrix
        /// </summary>
        void Visit(SymmetricMatrix<T> matrixA, SquareMatrix<T> matrixB);
        /// <summary>
        /// Visits diagonal and symmetric matrix
        /// </summary>
        void Visit(DiagonalMatrix<T> matrixA, SymmetricMatrix<T> matrixB);
        /// <summary>
        /// Visits symmetric and diagonal matrix
        /// </summary>
        void Visit(SymmetricMatrix<T> matrixA, DiagonalMatrix<T> matrixB);
    }
}
