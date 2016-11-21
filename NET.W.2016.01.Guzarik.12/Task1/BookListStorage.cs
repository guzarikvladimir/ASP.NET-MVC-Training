using System.Collections.Generic;
using System.IO;

namespace Task1
{
    /// <summary>
    /// Class to work with a storage of book's collection
    /// </summary>
    public sealed class BookListStorage : IBookStorage
    {
        private readonly string _fileName;

        /// <summary>
        /// Creates a new binary storage connected with a specified file
        /// </summary>
        public BookListStorage(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Saves the book's collection the the storage
        /// </summary>
        /// <remarks>If storage with the specified name does't exist, it will be created</remarks>
        public void SaveBooks(IEnumerable<Book> collection)
        {
            Stream stream;

            try
            {
                stream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            }
            catch (FileNotFoundException)
            {
                stream = new FileStream(_fileName, FileMode.CreateNew, FileAccess.Write);
            }
            var bw = new BinaryWriter(stream);

            foreach (var variable in collection)
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

        /// <summary>
        /// Loads the book's collecction from the storage
        /// </summary>
        /// <exception cref="NameNotFoundException">Wrong path to the storage</exception>
        public IEnumerable<Book> LoadBooks()
        {
            var collection = new List<Book>();
            try
            {
                using (Stream stream = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
                {
                    var br = new BinaryReader(stream);

                    while (br.PeekChar() != -1)
                    {
                        collection.Add(new Book(
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

            return collection;
        }
    }

    internal class NameNotFoundException : FileNotFoundException
    {
        public NameNotFoundException() { }

        public NameNotFoundException(string message, FileNotFoundException inner) : base(message, inner) { }
    }
}