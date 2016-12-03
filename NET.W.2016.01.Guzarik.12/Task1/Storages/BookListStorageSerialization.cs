using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1.Storages
{
    /// <summary>
    /// Serializes the collection to a binary file
    /// </summary>
    public sealed class BookListStorageSerialization : IBookStorage
    {
        private readonly string _path;

        /// <summary>
        /// Creates a new binary storage connected with a specified file
        /// </summary>
        public BookListStorageSerialization(string path)
        {
            _path = path + ".bin";
        }

        /// <summary>
        /// Serializes the book's collection to the storage
        /// </summary>
        /// <remarks>If storage with the specified name does't exist, it will be created</remarks>
        public void SaveBooks(IEnumerable<Book> collection)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(_path, FileMode.Create, FileAccess.Write))
            {
                foreach (var book in collection)
                {
                    formatter.Serialize(stream, book);
                }
            }
        }

        /// <summary>
        /// Loads the book's collecction from the storage
        /// </summary>
        /// <exception cref="BookListStorage.NameNotFoundException">Wrong path to the storage</exception>
        public IEnumerable<Book> LoadBooks()
        {
            IFormatter formatter = new BinaryFormatter();
            var collection = new List<Book>();

            try
            {
                using (Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    do
                    {
                        var book = (Book)formatter.Deserialize(stream);
                        collection.Add(book);
                    } while (true);
                }
            }
            catch (FileNotFoundException exc)
            {
                throw new NameNotFoundException(exc.FileName, exc);
            }
            catch
            {
                // ignored
            }

            return collection;
        }

        private class NameNotFoundException : FileNotFoundException
        {
            public NameNotFoundException(string message, FileNotFoundException inner) : base(message, inner) { }
        }
    }
}
