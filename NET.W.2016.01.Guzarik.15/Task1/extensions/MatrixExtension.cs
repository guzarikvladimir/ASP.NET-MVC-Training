using Task1.hierarchy;
using Task1.visitor;

namespace Task1.extensions
{
    /// <summary>
    /// Provides extension methods for square matrix
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Returns a square matrix which is the result of two matrix's sum 
        /// </summary>
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var visitor = new SumMatrixVisitor<T>();
            matrixA.Accept(visitor);
            return visitor.Sum;
        }
    }
}
