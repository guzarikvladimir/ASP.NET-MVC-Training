using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// A service to work with a collection of books
    /// </summary>
    public sealed class BookListService : IEnumerable<Book>
    {
        private readonly IBookRepository _repository;

        /// <summary>
        /// Creates a collection of book on specified repository
        /// </summary>
        public BookListService(IBookRepository repository)
        {
            _repository = repository;
        }

        #region Methods

        /// <summary>
        /// Add book to the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The book is already in the collection</exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            _repository.AddBook(book);
        }

        /// <summary>
        /// Remove book from the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The collection doesn't contain the book</exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            _repository.RemoveBook(book);
        }

        /// <summary>
        /// Returns the book from the collection that satisfies the specified information on the specified tag
        /// </summary>
        public Book FindBookByTag(Tag tag, string info)
        {
            return _repository.FindBookByTag(tag, info);
        }

        /// <summary>
        /// Sorts the collection on the specified tag
        /// </summary>
        public void SortBooksByTag(Tag tag)
        {
            _repository.SortBooksByTag(tag);
        }

        #endregion

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        public IEnumerator<Book> GetEnumerator()
        {
            return _repository.GetBooks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
