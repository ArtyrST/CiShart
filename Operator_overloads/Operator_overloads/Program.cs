namespace Operator_overloads
{
    class Square
    {
        int X { get; set; }
        public Square() : this(0) { }
        public Square(int x)
        {
            this.X = x;
        }
        public override string ToString()
        {
            return $"X : {X}.";
        }
        public static Square operator ++(Square p)
        {
            p.X++;
            return p;
        }
        public static Square operator --(Square p)
        {
            p.X--;
            return p;
        }
        public static Square operator +(Square p1, Square p2)
        {
            Square NewSquare = new Square()
            {
                X = p1.X + p2.X,
            };
            return NewSquare;
        }
        public static Square operator -(Square p1, Square p2)
        {
            if (p1.X > p2.X)
            {
                Square NewSquare = new Square()
                {
                    X = p1.X - p2.X,
                };
                return NewSquare;
            }
            else { return p1; }
        }
        public static Square operator *(Square p1, Square p2)
        {
            Square NewSquare = new Square()
            {
                X = p1.X * p2.X,
            };
            return NewSquare;
        }
        public static Square operator /(Square p1, Square p2)
        {
            Square NewSquare = new Square()
            {
                X = p1.X / p2.X,
            };
            return NewSquare;
        }
        public static bool operator ==(Square p1, Square p2)
        {

            return p1.Equals(p2);
        }

        public static bool operator !=(Square p1, Square p2)
        {
            return !(p1 == p2);
        }
        public static bool operator >(Square p1, Square p2)
        {
            return p1.X > p2.X;
        }

        public static bool operator <(Square p1, Square p2)
        {
            return p1.X < p2.X;
        }
        public static bool operator >=(Square p1, Square p2)
        {
            return p1.X >= p2.X;
        }

        public static bool operator <=(Square p1, Square p2)
        {
            return p1.X <= p2.X;
        }
        public static bool operator true(Square p1)
        {
            return p1.X >= 0;
        }
        public static bool operator false(Square p1)
        {
            return p1.X < 0;
        }

        public static implicit operator Rectangle(Square p)
        {
            return new Rectangle(p.X, 0);
        }

        public static implicit operator int(Square p)
        {
            return p.X;
        }

    }


    class Rectangle
    {
        int X { get; set; }
        int Y { get; set; }

        public Rectangle() : this(0, 0) { }

        public Rectangle(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"X : {X}, Y: {Y}.";
        }

        public static Rectangle operator ++(Rectangle p)
        {
            p.X++;
            p.Y++;
            return p;
        }

        public static Rectangle operator --(Rectangle p)
        {
            p.X--;
            p.Y--;
            return p;
        }

        public static Rectangle operator +(Rectangle p1, Rectangle p2)
        {
            Rectangle NewRectangle = new Rectangle()
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return NewRectangle;
        }

        public static Rectangle operator -(Rectangle p1, Rectangle p2)
        {
            if (p1.X > p2.X && p1.Y > p2.Y)
            {
                Rectangle NewRectangle = new Rectangle()
                {
                    X = p1.X - p2.X,
                    Y = p1.Y - p2.Y
                };
                return NewRectangle;
            }
            else { return p1; }
        }

        public static Rectangle operator *(Rectangle p1, Rectangle p2)
        {
            Rectangle NewRectangle = new Rectangle()
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return NewRectangle;
        }

        public static Rectangle operator /(Rectangle p1, Rectangle p2)
        {
            Rectangle NewRectangle = new Rectangle()
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return NewRectangle;
        }

        public static bool operator ==(Rectangle p1, Rectangle p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Rectangle p1, Rectangle p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(Rectangle p1, Rectangle p2)
        {
            return p1.X > p2.X && p1.Y > p2.Y;
        }

        public static bool operator <(Rectangle p1, Rectangle p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }

        public static bool operator >=(Rectangle p1, Rectangle p2)
        {
            return p1.X >= p2.X && p1.Y >= p2.Y;
        }

        public static bool operator <=(Rectangle p1, Rectangle p2)
        {
            return p1.X <= p2.X && p1.Y <= p2.Y;
        }

        public static bool operator true(Rectangle p1)
        {
            return p1.X >= 0 && p1.Y >= 0;
        }

        public static bool operator false(Rectangle p1)
        {
            return p1.X < 0 || p1.Y < 0;
        }

        public static implicit operator Square(Rectangle p)
        {
            return new Square(p.X);
        }
        public static explicit operator int(Rectangle p) {
            return p.X + p.Y;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
