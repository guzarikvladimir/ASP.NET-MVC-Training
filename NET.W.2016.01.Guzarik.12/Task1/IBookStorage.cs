using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Provides methods for storage management
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Saves books to storage
        /// </summary>
        void SaveBooks(IEnumerable<Book> collection);
        /// <summary>
        /// Loads books from storage
        /// </summary>
        IEnumerable<Book> LoadBooks();
    }
}
