using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task1;

namespace Task2.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void Add_IntDefaultComparer()
        {
            var tree = new BinarySearchTree<int>();
            var rand = new Random();

            for (var i = 0; i < 10; i++)
                tree.Add(rand.Next(30));

            Print(tree);
        }

        [Test]
        public void Add_IntCustomComparer()
        {
            var tree = new BinarySearchTree<int>(new IntComparer());
            var rand = new Random();

            for (var i = 0; i < 10; i++)
                tree.Add(rand.Next(30));

            Print(tree);
        }

        [Test]
        public void Add_StringDefaultComparer()
        {
            var tree = new BinarySearchTree<string>();
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            tree.Add("six");
            tree.Add("seven");
            tree.Add("four");

            Print(tree);
        }

        [Test]
        public void Add_StringCustomComparer()
        {
            var tree = new BinarySearchTree<string>(new StringComparer());
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            tree.Add("six");
            tree.Add("seven");
            tree.Add("four");

            Print(tree);
        }

        [Test]
        public void Add_BookDefaultComparer()
        {
            var tree = new BinarySearchTree<Book>();
            tree.Add(new Book("Паттерны проектирования на платформе .NET",
                "Сергей Тепляков", "Питер", 2015, "Русский"));
            tree.Add(new Book("Оптимизация приложений на платформе .NET",
                "Саша Годштейн", "ДМК Пресс", 2014, "Русский"));
            tree.Add(new Book("C# in depth", "Джон Скит", year: 2014,
                language: "Русский"));
            tree.Add(new Book("C# 5.0. Справочник. Полное описание языка",
                "Джозеф албахари", year: 2014, language: "Русский"));
            tree.Add(new Book("CLR via C#", "Джеффри Рихтер", language: "Русский"));

            Print(tree);
        }

        [Test]
        public void Add_BookCustomComparer()
        {
            var tree = new BinarySearchTree<Book>(new BookComparer());
            tree.Add(new Book("Паттерны проектирования на платформе .NET",
                "Сергей Тепляков", "Питер", 2015, "Русский"));
            tree.Add(new Book("Оптимизация приложений на платформе .NET",
                "Саша Годштейн", "ДМК Пресс", 2014, "Русский"));
            tree.Add(new Book("C# in depth", "Джон Скит", year: 2014,
                language: "Русский"));
            tree.Add(new Book("C# 5.0. Справочник. Полное описание языка",
                "Джозеф албахари", year: 2014, language: "Русский"));
            tree.Add(new Book("CLR via C#", "Джеффри Рихтер", language: "Русский"));

            Print(tree);
        }

        [Test]
        public void Add_PointCustomComparer()
        {
            var tree = new BinarySearchTree<Point>(new PointComparer());
            var rand = new Random();

            for (var i = 0; i < 10; i++)
                tree.Add(new Point(rand.Next(30), rand.Next(30)));

            Print(tree);
        }

        private static void Print<T>(BinarySearchTree<T> tree)
        {
            Console.WriteLine("Inorder:");
            foreach (var variable in tree.Inorder())
                Console.WriteLine(variable);

            Console.WriteLine("Postorder:");
            foreach (var variable in tree.Postorder())
                Console.WriteLine(variable);

            Console.WriteLine("Preorder:");
            foreach (var variable in tree.Preorder())
                Console.WriteLine(variable);
        }

        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x < y) return -1;
                return x > y ? 1 : 0;
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Length.CompareTo(y.Length);
            }
        }

        private class BookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return string.Compare(x.Author, y.Author, StringComparison.Ordinal);
            }
        }

        private class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return (x.X + x.Y).CompareTo(y.X + y.Y);
            }
        }

        private struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"x: {X}, y: {Y}";
            }
        }
    }
}