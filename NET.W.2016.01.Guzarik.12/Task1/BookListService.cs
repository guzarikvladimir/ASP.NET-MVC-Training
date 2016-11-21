using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// A service to work with a collection of books
    /// </summary>
    public sealed class BookListService
    {
        private SortedSet<Book> _collection;

        #region Constructors

        /// <summary>
        /// Creates an empty collection of book
        /// </summary>
        public BookListService()
        {
            _collection = new SortedSet<Book>();
        }

        #endregion

        #region API

        /// <summary>
        /// Add book to the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The book is already in the collection</exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));

            if (_collection.Contains(book))
                throw new ArgumentException(nameof(book));

            _collection.Add(book);
        }

        /// <summary>
        /// Remove book from the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The collection doesn't contain the book</exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));

            if (!_collection.Contains(book))
                throw new ArgumentException(nameof(book));

            _collection.Remove(book);
        }

        /// <summary>
        /// Returns the book from the collection that satisfies the specified information comparison
        /// </summary>
        public Book FindBookByTag(Func<Book, bool> predicate)
        {
            if (ReferenceEquals(predicate, null))
                throw new ArgumentNullException(nameof(predicate));

            return _collection.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Sorts the collection on the specified comparer
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            _collection = new SortedSet<Book>(_collection, comparer);
        }

        /// <summary>
        /// Sorts the collection on the specified comparison
        /// </summary>
        public void SortBooksByTag(Comparison<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            SortBooksByTag(new ComparisonAdapter(comparer));
        }

        /// <summary>
        /// Saves the book's collection the the specified storage
        /// </summary>
        public void SaveBooks(IBookStorage storage)
        {
            storage.SaveBooks(_collection);
        }

        /// <summary>
        /// Loads the book's collecction from the specified storage
        /// </summary>
        public void LoadBooks(IBookStorage storage)
        {
            _collection = new SortedSet<Book>(storage.LoadBooks());
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>) _collection).GetEnumerator();
        }

        #endregion

        #region ComparisonAdapter

        private class ComparisonAdapter : IComparer<Book>
        {
            private readonly Comparison<Book> _comparison;

            public ComparisonAdapter(Comparison<Book> comparer)
            {
                _comparison = comparer;
            }
            public int Compare(Book x, Book y)
            {
                return _comparison.Invoke(x, y);
            }
        }

        #endregion
    }
}
