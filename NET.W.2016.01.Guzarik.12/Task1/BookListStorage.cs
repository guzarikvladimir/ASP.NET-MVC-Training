using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Class to work with a storage of book's collection
    /// </summary>
    public sealed class BookListStorage : IBookRepository
    {
        private volatile List<Book> _collection;
        private const int DefaultCapacity = 5;

        #region Properties

        /// <summary>
        /// A path to book's storage
        /// </summary>
        public string FilePath { get; set; } = "BooksStorage.txt";

        /// <summary>
        /// Returns the book's collection
        /// </summary>
        /// <remarks>If collection is empty, the collection will load from the storage</remarks>
        /// <exception cref="NameNotFoundException">Wrong path to the storage</exception>
        public IEnumerable<Book> GetBooks
        {
            get
            {
                if (_collection == null)
                {
                    ReadBooks();
                }

                return _collection;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates empty virtual books storage
        /// </summary>
        public BookListStorage()
        {
            _collection = new List<Book>(DefaultCapacity);
        }

        /// <summary>
        /// Loads book's collection from the storage
        /// </summary>
        public BookListStorage(string path)
        {
            FilePath = path;
            ReadBooks();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds book to the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The book is already in the collection</exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (_collection.Contains(book))
            {
                throw new ArgumentException(nameof(book));
            }

            _collection.Add(book);
        }

        /// <summary>
        /// Removes book from the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The book is undefined</exception>
        /// <exception cref="ArgumentException">The collection doesn't contain the book</exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            if (!_collection.Contains(book))
            {
                throw new ArgumentException(nameof(book));
            }

            _collection.Remove(book);
        }

        /// <summary>
        /// Returns the book from the collection that satisfies the specified information on the specified tag
        /// </summary>
        public Book FindBookByTag(Tag tag, string info)
        {
            return _collection.FirstOrDefault(variable => variable.Equals(tag, info));
        }

        /// <summary>
        /// Sorts the collection on the specified tag
        /// </summary>
        public void SortBooksByTag(Tag tag)
        {
            _collection.Sort((x, y) => x.CompareTo(y, tag));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads the book's collecction from the storage
        /// </summary>
        /// <exception cref="NameNotFoundException">Wrong path to the storage</exception>
        private void ReadBooks()
        {
            try
            {
                using (Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    var br = new BinaryReader(stream);
                    _collection = new List<Book>(DefaultCapacity);

                    while (br.PeekChar() != -1)
                    {
                        AddBook(new Book(
                            br.ReadString(),
                            br.ReadString(),
                            br.ReadString(),
                            br.ReadInt32(),
                            br.ReadString()));
                    }
                }
            }
            catch (FileNotFoundException exc)
            {
                throw new NameNotFoundException(exc.FileName, exc);
            }
        }

        /// <summary>
        /// Saves the book's collection the the storage
        /// </summary>
        private void SaveBooks()
        {
            Stream stream;

            try
            {
                stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            }
            catch (FileNotFoundException)
            {
                stream = new FileStream(FilePath, FileMode.CreateNew, FileAccess.Write);
            }
            var bw = new BinaryWriter(stream);

            foreach (var variable in _collection)
            {
                bw.Write(variable.Name ?? "Unknown");
                bw.Write(variable.Author ?? "Unknown");
                bw.Write(variable.PublishingHouse ?? "Unknown");
                bw.Write(variable.Year ?? 0);
                bw.Write(variable.Language ?? "Unknown");
            }

            bw.Flush();
            bw.Close();
            stream.Close();
        }

        #endregion

        /// <summary>
        /// Saves the collection to the storage at the end of the work
        /// </summary>
        ~BookListStorage()
        {
            SaveBooks();
        }
    }

    internal class NameNotFoundException : FileNotFoundException
    {
        public NameNotFoundException() { }

        public NameNotFoundException(string message, FileNotFoundException inner) : base(message, inner) { }
    }
}