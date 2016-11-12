using System;

namespace Task2
{
    /// <summary>
    /// Class for working with square
    /// </summary>
    public class Square : Rectangle
    {
        /// <summary>
        /// Constructor for building square on rectangle's constructor
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public Square(double side) : base(side, side) { }

        /// <summary>
        /// Returns incircle radius of the square
        /// </summary>
        public double IncircleRadius() => Width / 2;
    }
}
