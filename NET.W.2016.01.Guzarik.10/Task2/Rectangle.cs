using System;

namespace Task2
{
    /// <summary>
    /// Class for working with Rectangle
    /// </summary>
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        /// <summary>
        /// Constructor for building rectangle on two sides
        /// </summary>
        /// <exception cref="ArgumentException">Throws when arguments less then 0</exception>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Allows get or set width of the rectangle
        /// </summary>
        /// /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double Width
        {
            get { return _width; }
            private set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Allows get or set height of the rectangle
        /// </summary>
        /// /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double Height
        {
            get { return _height; }
            private set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Returns circumcircle radius of the rectangle
        /// </summary>
        public virtual double CircumcircleRadius() => Math.Sqrt(Math.Pow(_width, 2) + Math.Pow(_height, 2))/2;

        /// <summary>
        /// Returns area of the rectangle
        /// </summary>
        public override double Area() => _width*_height;

        /// <summary>
        /// Returns perimeter of the rectangle
        /// </summary>
        public override double Perimeter() => (_width + _height)*2;

        /// <summary>
        /// Returns the same new object Rectangle 
        /// </summary>
        public override object Clone() => new Rectangle(_width, _height);

        /// <summary>
        /// Determines whether two rectangles are equal
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Rectangle);

        /// <summary>
        /// Determines whether two rectangles are equal
        /// </summary>
        public bool Equals(Rectangle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Equals(_width, other._width) && Equals(_height, other._height);
        }

        /// <summary>
        /// Returns object's hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (_width.GetHashCode()*397) ^ _height.GetHashCode();
            }
        }
    }
}
