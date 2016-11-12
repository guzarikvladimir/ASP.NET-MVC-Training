using System;

namespace Task2
{
    /// <summary>
    /// Abstract class reflects shape
    /// </summary>
    public abstract class Shape : ICloneable
    {
        /// <summary>
        /// Returns area of the shape
        /// </summary>
        public abstract double Area();

        /// <summary>
        /// Returns perimeter of the shape
        /// </summary>
        public abstract double Perimeter();

        /// <summary>
        /// Returns the same new object shape
        /// </summary>
        public abstract object Clone();
    }
}
