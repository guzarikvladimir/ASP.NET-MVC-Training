using System;

namespace Task2
{
    /// <summary>
    /// Class for working with triangle
    /// </summary>
    public class Triangle : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        /// <summary>
        /// Constructor for creating a common triangle
        /// </summary>
        /// <exception cref="ArgumentException">Throws when arguments less then 0</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Constructor for creating an equilateral triangle
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public Triangle(double side)
        {
            SideA = SideB = SideC = side;
        }

        /// <summary>
        /// Allows get or set first side
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _sideA = value;
            }
        }

        /// <summary>
        /// Allows get or set second side
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _sideB = value;
            }
        }

        /// <summary>
        /// Allows get or set third side
        /// </summary>
        /// <exception cref="ArgumentException">Throws when argument less then 0</exception>
        public double SideC
        {
            get { return _sideC; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _sideC = value;
            }
        }

        /// <summary>
        /// Returns area of the triangle
        /// </summary>
        public override double Area() =>
            Math.Sqrt(Semiperimeter()*(Semiperimeter() - _sideA)*(Semiperimeter() - _sideB)*(Semiperimeter() - _sideC));

        /// <summary>
        /// Returns perimeter of the triangle
        /// </summary>
        /// <returns></returns>
        public override double Perimeter() => _sideA + _sideB + _sideC;

        /// <summary>
        /// Returns the same new object Triangle 
        /// </summary>
        public override object Clone() => new Triangle(_sideA, _sideB, _sideC);

        /// <summary>
        /// Determines whether the triangle is equilateral
        /// </summary>
        public bool IsEquilateral() => Equals(_sideA, _sideB) & Equals(_sideA, _sideC);

        /// <summary>
        /// Determines whether the triangle is isosceles
        /// </summary>
        public bool IsIsosceles() => Equals(_sideA, _sideB) || Equals(_sideA, _sideC) || Equals(_sideB, _sideC);

        /// <summary>
        /// Determines whether two triangles are equal
        /// </summary>
        public bool Equals(Triangle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Equals(_sideA, other._sideA) & Equals(_sideB, other.SideB) & Equals(_sideC, other._sideC);
        }

        /// <summary>
        /// Determines whether two triangles are equal
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Triangle);

        /// <summary>
        /// Reterns object's hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _sideA.GetHashCode();
                hashCode = (hashCode*397) ^ _sideB.GetHashCode();
                hashCode = (hashCode*397) ^ _sideC.GetHashCode();
                return hashCode;
            }
        }

        private double Semiperimeter() => (_sideA + _sideB + _sideC)/2;
    }
}
