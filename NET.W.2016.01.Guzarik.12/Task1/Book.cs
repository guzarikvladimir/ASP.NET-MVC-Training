using System;
using System.CodeDom.Compiler;

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
        public Book(string name = null, string author = null, string publishingHouse = null, 
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
            {
                throw new ArgumentException(nameof(obj));
            }
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
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                   string.Compare(Author, other.Author, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                   string.Compare(PublishingHouse, other.PublishingHouse, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                   string.Compare(Language, other.Language, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                   Year == other.Year;
        }

        /// <summary>
        /// Determines whethet the specified book object is equal to the current object on the specified tag
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The incorrect tag</exception>
        public bool Equals(Tag tag, string info)
        {
            switch (tag)
            {
                case Tag.Name:
                    return string.Compare(Name, info, StringComparison.InvariantCultureIgnoreCase) == 0;
                case Tag.Author:
                    return string.Compare(Author, info, StringComparison.InvariantCultureIgnoreCase) == 0;
                case Tag.PublishingHouse:
                    return string.Compare(PublishingHouse, info, StringComparison.InvariantCultureIgnoreCase) == 0;
                case Tag.Year:
                    return Year == int.Parse(info);
                case Tag.Language:
                    return string.Compare(Language, info, StringComparison.InvariantCultureIgnoreCase) == 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
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
            return CompareTo(other, Tag.Name);
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
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return CompareTo(otherBook, Tag.Name);
        }

        /// <summary>
        /// Compares the current instance with another book object on the specified tag
        /// </summary>
        /// <remarks>Less than zero - This instance precedes obj in the sort order.
        /// Zero - This instance occurs in the same position in the sort order as obj.
        /// Greater than zero - This instance follows obj in the sort order.</remarks>
        /// <returns>Returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object</returns>
        /// <exception cref="ArgumentOutOfRangeException">The incorrect tag</exception>
        public int CompareTo(Book other, Tag tag)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            switch (tag)
            {
                case Tag.Name:
                    return string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
                case Tag.Author:
                    return string.Compare(Author, other.Author, StringComparison.InvariantCultureIgnoreCase);
                case Tag.PublishingHouse:
                    return string.Compare(PublishingHouse, other.PublishingHouse, StringComparison.InvariantCultureIgnoreCase);
                case Tag.Year:
                    if (Year < other.Year) return -1;
                    return Year > other.Year ? 1 : 0;
                case Tag.Language:
                    return string.Compare(Language, other.Language, StringComparison.InvariantCultureIgnoreCase);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
        }

        #endregion
    }

    /// <summary>
    /// The criterion for comparison or search object
    /// </summary>
    public enum Tag
    {
        /// <summary>
        /// Sort or find by name
        /// </summary>
        Name,
        /// <summary>
        /// Sort or find by Author
        /// </summary>
        Author,
        /// <summary>
        /// Sort or find by PublishingHouse
        /// </summary>
        PublishingHouse,
        /// <summary>
        /// Sort or find by Year
        /// </summary>
        Year,
        /// <summary>
        /// Sort or find by Language
        /// </summary>
        Language
    }
}
