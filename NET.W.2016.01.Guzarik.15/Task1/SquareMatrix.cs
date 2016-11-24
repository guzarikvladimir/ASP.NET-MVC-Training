using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Class represents a square matrix
    /// </summary>
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Matrix storage
        /// </summary>
        protected readonly T[,] Matrix;
        private int _rank;
        private MatrixSender _setterSender;

        #region Properties

        /// <summary>
        /// Returns the order of the matrix
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws when rank less than 2</exception>
        public int Rank
        {
            get { return _rank; }
            private set
            {
                if (value < 2)
                    throw new ArgumentOutOfRangeException("The matrix cannot have rank less than 2");

                _rank = value;
            }
        }

        /// <summary>
        /// Returns message of changed index
        /// </summary>
        public string MessageFromIndexSetted { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a clear square matrix with specified rank
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws when rank less than 2</exception>
        public SquareMatrix(int rank)
        {
            Rank = rank;
            Matrix = new T[rank, rank];
        }

        /// <summary>
        /// Creates a square matrix on specified collection
        /// </summary>
        /// <exception cref="ArgumentException">Throws when matrix cannot be a square with such amount of elements</exception>
        public SquareMatrix(IEnumerable<T> elements) : this(elements.ToArray()) { }

        /// <summary>
        /// Creates a square matrix on a number of elements
        /// </summary>
        /// <exception cref="ArgumentException">Throws when matrix cannot be a square with such amount of elements</exception>
        public SquareMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            Matrix = new T[_rank, _rank];
            InitMatrix(elements);
        }

        /// <summary>
        /// Creates a square matrix on another square matrix
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when input matrix is null</exception>
        /// <exception cref="ArgumentException">Throws when matrix cannot be a square with such amount of elements</exception>
        public SquareMatrix(SquareMatrix<T> matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));

            Rank = matrix.Rank;
            Matrix = new T[matrix.Rank, matrix.Rank];
            Array.Copy(matrix.Matrix, Matrix, matrix.Matrix.Length);
        }

        #endregion

        #region API

        /// <summary>
        /// Registers on event about index changes
        /// </summary>
        public void RegisterOnIndexSetted(MatrixSender setterSender)
        {
            if (ReferenceEquals(_setterSender, null))
                _setterSender = setterSender;

            _setterSender.IndexSetted += ActWhenIndexSetted;
        }

        /// <summary>
        /// Unregisters from event about index changes
        /// </summary>
        public void UnregisterFromIndexSetted(MatrixSender setterSender)
        {
            _setterSender.IndexSetted -= ActWhenIndexSetted;
            _setterSender = null;
        }

        /// <summary>
        /// Returns a string represantation of the matrix with standad tab
        /// </summary>
        public override string ToString()
        {
            return ToString(1);
        }

        /// <summary>
        /// Returns a string represantation of the matrix with the specified amount of tabs
        /// </summary>
        /// <param name="separatorCount">The number of tabs</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when the number of separators less than 0</exception>
        public string ToString(int separatorCount)
        {
            if (separatorCount < 0)
                throw new ArgumentOutOfRangeException(nameof(separatorCount));

            var tmp = new StringBuilder(Matrix.Length);

            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    tmp.Append(Matrix[i, j]);
                    tmp.Append('\t', separatorCount);
                }
                tmp.Append(Environment.NewLine);
            }

            return tmp.ToString();
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Returns or sets value on specified index
        /// </summary>
        /// <remarks>If matrix is subscribed on index changed, it notifies about changes</remarks>
        /// <exception cref="ArgumentOutOfRangeException">Throws when index i or j less than 0</exception>
        public virtual T this[int i, int j]
        {
            get { return Matrix[i, j]; }
            set
            {
                if (i < 0 || i > Rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j > Rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                Matrix[i, j] = value;

                _setterSender?.Notify($"Index [{i},{j}] has changed");
            }
        }

        #endregion

        #region Private Methods

        private static int TryGetRank(params T[] elements)
        {
            var rank = (int)Math.Sqrt(elements.Length);

            if (rank * rank != elements.Length)
                throw new ArgumentException("The matrix is not a square");

            return rank;
        }

        private void InitMatrix(params T[] elements)
        {
            var count = 0;

            for (var i = 0; i < Rank; i++)
                for (var j = 0; j < Rank; j++)
                    Matrix[i, j] = elements[count++];
        }

        private void ActWhenIndexSetted(object sender, SetterEventArgs eventArgs)
        {
            MessageFromIndexSetted += eventArgs.Message;
        }

        #endregion
    }
}
