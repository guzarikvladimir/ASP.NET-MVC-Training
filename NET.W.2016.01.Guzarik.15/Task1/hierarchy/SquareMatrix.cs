using System;
using System.Collections.Generic;
using System.Linq;
using Task1.visitor;

namespace Task1.hierarchy
{
    /// <summary>
    /// Class represents a square matrix
    /// </summary>
    public class SquareMatrix<T> : ICloneable
    {
        private readonly T[,] _matrix;
        private int _rank;

        #region Properties

        /// <summary>
        /// Returns or sets a rank of matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when rank less than 2</exception>
        public virtual int Rank
        {
            get { return _rank; }
            protected set
            {
                if (value < 2)
                    throw new ArgumentException("The matrix connot have rank less than 2");

                _rank = value;
            }
        }

        /// <summary>
        /// Stores a message about changing the value of the element
        /// </summary>
        public virtual string MessageFromIndexSetted { get; protected set; }

        /// <summary>
        /// Event about changing the value of the element
        /// </summary>
        protected event EventHandler<string> IndexSetted;

        #endregion

        #region Constructors

        /// <summary>
        /// Registers the event for successors
        /// </summary>
        protected SquareMatrix()
        {
            IndexSetted += ActWhenIndexSetted;
        }

        /// <summary>
        /// Creates an empty square matrix on specified rank (order)
        /// </summary>
        public SquareMatrix(int rank)
        {
            Rank = rank;
            _matrix = new T[_rank, _rank];
            IndexSetted += ActWhenIndexSetted;
        }

        /// <summary>
        /// Creates a square matrix on specified collection of elements with event registration
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements</exception>
        public SquareMatrix(params T[] elements)
        {
            Rank = TryGetRank(elements);
            _matrix = new T[_rank, _rank];
            InitMatrix(elements);
            IndexSetted += ActWhenIndexSetted;
        }

        /// <summary>
        /// Creates a square matrix on specified collection of elements with event registration
        /// </summary>
        /// <exception cref="ArgumentException">Throws when it is impossible to build a square matrix on specified elements</exception>
        public SquareMatrix(IEnumerable<T> elements) : this(elements.ToArray()) { }

        #endregion

        #region API

        /// <summary>
        /// Returns or sets value on specified index
        /// </summary>
        /// <remarks>Notifies about setting a value to the special element</remarks>
        /// <exception cref="ArgumentOutOfRangeException">Throws when indexes less than 0 or bigger than actual rank of matrix</exception>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= _rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= _rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                return _matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= _rank)
                    throw new ArgumentOutOfRangeException(nameof(i));

                if (j < 0 || j >= _rank)
                    throw new ArgumentOutOfRangeException(nameof(j));

                OnIndexSetted($"Index [{i},{j}] has changed in square matrix" + Environment.NewLine);

                _matrix[i, j] = value;
            }
        }

        /// <summary>
        /// Returns a deep copy of the symmetric matrix
        /// </summary>
        public SquareMatrix<T> Clone()
        {
            var clone = new SquareMatrix<T>(Rank);

            for (var i = 0; i < Rank; i++)
                for (var j = 0; j < Rank; j++)
                    clone[i, j] = _matrix[i, j];

            return clone;
        }

        /// <summary>
        /// Iterates throug the square matrix
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            return _matrix.Cast<T>().GetEnumerator();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Colculates and returns the rank of square matrix
        /// </summary>
        /// <exception cref="ArgumentException">Throws when the matrix is not a square</exception>
        protected static int TryGetRank(IEnumerable<T> elements)
        {
            var enumerable = elements as T[] ?? elements.ToArray();
            var rank = (int)Math.Sqrt(enumerable.Length);

            if (rank * rank != enumerable.Length)
                throw new ArgumentException("The matrix is not a square");

            return rank;
        }

        /// <summary>
        /// Occurs when index changes
        /// </summary>
        protected void OnIndexSetted(string message)
        {
            IndexSetted?.Invoke(this, message);
        }

        /// <summary>
        /// Responds to the occurrence of events
        /// </summary>
        protected virtual void ActWhenIndexSetted(object sender, string message)
        {
            MessageFromIndexSetted += message;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a square matrix with specified collection of elements
        /// </summary>
        private void InitMatrix(IEnumerable<T> elements)
        {
            var tmp = elements.ToArray();
            var counter = 0;

            for (var i = 0; i < _rank; i++)
                for (var j = 0; j < _rank; j++)
                    _matrix[i, j] = tmp[counter++];
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        /// <summary>
        /// Accepts a class visitor
        /// </summary>
        public void Accept(IMatrixVisitor<T> visitor) => visitor.Visit((dynamic) this, (dynamic) this);
    }
}
