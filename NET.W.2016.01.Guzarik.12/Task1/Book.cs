using System;

namespace Task1
{
    /// <summary>
    /// Class describes the book
    /// </summary>
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        #region Properties

        /// <summary>
        /// The name of the book object
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The author of the book object
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// The publishing house of the book object
        /// </summary>
        public string PublishingHouse { get; }

        /// <summary>
        /// The year of tpublishing of the book object
        /// </summary>
        public int? Year { get; }

        /// <summary>
        /// The language of the book object
        /// </summary>
        public string Language { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the object object with specified information
        /// </summary>
        public Book(string name, string author = null, string publishingHouse = null, 
            int? year = null, string language = null)
        {
            Name = name;
            Author = author;
            PublishingHouse = publishingHouse;
            Year = year;
            Language = language;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string representation of the object
        /// </summary>
        public override string ToString()
        {
            return
                $"Name: {Name ?? "Unknown"}{Environment.NewLine}" + 
                $"Author: {Author ?? "Unknown"}{Environment.NewLine}" +
                $"PublishiingHouse: {PublishingHouse ?? "Unknown"}{Environment.NewLine}" +
                $"Year: {Year ?? 0}{Environment.NewLine}" +
                $"Language: {Language ?? "Unknown"}{Environment.NewLine}";
        }

        /// <summary>
        /// Determines whethet the specified object is equal to the current object
        /// </summary>
        /// <exception cref="ArgumentException">The object is not a book</exception>
        public override bool Equals(object obj)
        {
            var otherBook = obj as Book;

            if (ReferenceEquals(otherBook, null))
                throw new ArgumentException(nameof(obj));

            return Equals(otherBook);
        }

        /// <summary>
        /// Serves as the default hash function
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Author?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PublishingHouse?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Year.GetHashCode();
                hashCode = (hashCode*397) ^ (Language?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        /// <summary>
        /// Determines whethet the specified book object is equal to the current object
        /// </summary>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Author, other.Author, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(PublishingHouse, other.PublishingHouse, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Language, other.Language, StringComparison.InvariantCultureIgnoreCase) &&
                   Year == other.Year;
        }

        /// <summary>
        /// Compares the current instance with another book object
        /// </summary>
        /// <remarks>Less than zero - This instance precedes obj in the sort order.
        /// Zero - This instance occurs in the same position in the sort order as obj.
        /// Greater than zero - This instance follows obj in the sort order.</remarks>
        /// <returns>Returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException();

            return string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type
        /// </summary>
        /// <remarks>Less than zero - This instance precedes obj in the sort order.
        /// Zero - This instance occurs in the same position in the sort order as obj.
        /// Greater than zero - This instance follows obj in the sort order.</remarks>
        /// <returns>Returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object</returns>
        public int CompareTo(object obj)
        {
            var otherBook = obj as Book;

            if (ReferenceEquals(otherBook, null))
                throw new ArgumentNullException(nameof(obj));

            return CompareTo(otherBook);
        }

        #endregion
    }
}
