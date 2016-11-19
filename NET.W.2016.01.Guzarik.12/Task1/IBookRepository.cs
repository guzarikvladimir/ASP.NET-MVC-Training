using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// The book's repository. Provides methods for storage management
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Returns the book's collection
        /// </summary>
        IEnumerable<Book> GetBooks { get; }
        /// <summary>
        /// Adds book to the collection
        /// </summary>
        void AddBook(Book book);
        /// <summary>
        /// Removes book from the collection
        /// </summary>
        void RemoveBook(Book book);
        /// <summary>
        /// Returns the book from the collection that satisfies the specified information on the specified tag
        /// </summary>
        Book FindBookByTag(Tag tag, string info);
        /// <summary>
        /// Sorts the collection on the specified tag
        /// </summary>
        void SortBooksByTag(Tag tag);
    }
}
