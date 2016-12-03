using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Task1.Storages
{
    /// <summary>
    /// Class to work with xml storage
    /// </summary>
    public sealed class BookListStorageXml : IBookStorage
    {
        private readonly string _path;

        /// <summary>
        /// Creates a new xml storage
        /// </summary>>
        public BookListStorageXml(string path)
        {
            _path = path + ".xml";
        }

        /// <summary>
        /// Saves the book's collection to the xml storage
        /// </summary>
        /// <remarks>If storage with the specified name does't exist, it will be created</remarks>
        public void SaveBooks(IEnumerable<Book> collection)
        {
            using (var writer = new XmlTextWriter(_path, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;

                foreach (var book in collection)
                {
                    writer.WriteStartElement("book");

                    writer.WriteStartElement("title");
                    writer.WriteString(book.Name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("author");
                    writer.WriteString(book.Author);
                    writer.WriteEndElement();

                    writer.WriteStartElement("publishingHouse");
                    writer.WriteString(book.PublishingHouse);
                    writer.WriteEndElement();

                    writer.WriteStartElement("year");
                    writer.WriteString(book.Year.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("language");
                    writer.WriteString(book.Language);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Loads the book's collecction from the xml storage
        /// </summary>
        /// <exception cref="BookListStorage.NameNotFoundException">Wrong path to the storage</exception>
        public IEnumerable<Book> LoadBooks()
        {
            var collection = new List<Book>();

            try
            {
                using (Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read))
                using (var reader = new XmlTextReader(stream))
                {
                    while (reader.Read())
                    {
                        int? year = null;

                        Skip(reader);
                        var name = reader.Value;
                        Skip(reader);
                        var author = reader.Value;
                        Skip(reader);
                        var publishingHouse = reader.Value;
                        Skip(reader);
                        try
                        {
                            year = int.Parse(reader.Value);
                        }
                        catch
                        {
                            // ignored
                        }
                        Skip(reader);
                        var language = reader.Value;

                        var book = new Book(name, author, publishingHouse, year, language);
                        collection.Add(book);
                    }
                }
            }
            catch (FileNotFoundException exc)
            {
                throw new NameNotFoundException(exc.FileName, exc);
            }

            return collection;
        }

        private static void Skip(XmlTextReader reader)
        {
            reader.Read();
            while (reader.NodeType != XmlNodeType.Text)
                reader.Read();
        }

        private class NameNotFoundException : FileNotFoundException
{
    public NameNotFoundException(string message, FileNotFoundException inner) : base(message, inner) { }
}
    }
}
