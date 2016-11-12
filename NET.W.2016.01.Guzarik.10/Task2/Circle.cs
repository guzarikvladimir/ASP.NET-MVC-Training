using System;

namespace Task2
{
    /// <summary>
    /// Class for working with the circle
    /// </summary>
    public class Circle : Shape
    {
        private double _radius;

        /// <summary>
        /// Constructor for building circle on radius
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Allows get or set radius
        /// </summary>
        ///  /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();

                _radius = value;
            }
        }

        /// <summary>
        /// Returns sector of the circle on angle
        ///  /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        /// </summary>
        public double Sector(double angle) => Math.PI*Math.Pow(_radius, 2)*FormatAngle(angle)/360;

        /// <summary>
        /// Returns segment of the circle on angle
        /// </summary>
        ///  /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double Segment(double angle)
            => Math.Pow(_radius, 2)/2*(Math.PI*FormatAngle(angle)/180 - Math.Sin(angle*Math.PI/180));

        /// <summary>
        /// Returns area of the circle
        /// </summary>
        public override double Area() => Math.PI*Math.Pow(_radius, 2);

        /// <summary>
        /// Returns perimeter of the circle
        /// </summary>
        public override double Perimeter() => 2*Math.PI*_radius;

        /// <summary>
        /// Returns the same new object Circle 
        /// </summary>
        public override object Clone() => new Circle(_radius);

        /// <summary>
        /// Determines whether two circles are equal
        /// </summary>
        public bool Equals(Circle other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(_radius, other.Radius);
        }

        /// <summary>
        /// Determines whether two circles are equal
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Circle);

        /// <summary>
        /// Returns object's hash code
        /// </summary>
        public override int GetHashCode() => _radius.GetHashCode();

        private static double FormatAngle(double angle)
        {
            if (angle < 0)
                throw new ArgumentException();

            while (angle > 360)
                angle -= 360;

            return angle;
        }
    }
}
