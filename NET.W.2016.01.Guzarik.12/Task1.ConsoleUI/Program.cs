using System;
using System.Collections.Generic;
using NLog;
using Task1.Storages;

namespace Task1.ConsoleUI
{
    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            var service = new BookListService();

            Console.WriteLine("--------------------Добавление---------------");
            Console.WriteLine();

            var book1 = new Book("Паттерны проектирования на платформе .NET",
                "Сергей Тепляков", "Питер", 2015, "Русский");
            var book2 = new Book("Оптимизация приложений на платформе .NET",
                "Саша Годштейн", "ДМК Пресс", 2014, "Русский");
            var book3 = new Book("C# in depth", "Джон Скит", year: 2014,
                language: "Русский");
            var book4 = new Book("C# 5.0. Справочник. Полное описание языка",
                "Джозеф албахари", year: 2014, language: "Русский");
            var book5 = new Book("CLR via C#", "Джеффри Рихтер", language: "Русский");

            Book[] books = { book1, book2, book3, book4, book5 };

            foreach (var variable in books)
            {
                try
                {
                    service.AddBook(variable);
                }
                catch (ArgumentException exc)
                {
                    Logger.Info("Adding element. Element exists in the collection:");
                    Logger.Error(exc.StackTrace);
                }
                catch (Exception exc)
                {
                    Logger.Info("Unhandled adding exception:");
                    Logger.Error(exc.StackTrace);
                }
            }

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("--------------------Удаление-----------------");
            Console.WriteLine();

            var defBook = new Book("Unknown", "Unknown");

            Book[] removingBooks = { book5, defBook };

            foreach (var variable in removingBooks)
            {
                try
                {
                    service.RemoveBook(variable);
                }
                catch (ArgumentException exc)
                {
                    Logger.Info("Removing element. The element are not in the collection:");
                    Logger.Error(exc.Message);
                    Logger.Error(exc.Data);
                    Logger.Error(exc.Source);
                    Logger.Error(exc.TargetSite);
                    Logger.Error(exc.StackTrace);
                }
                catch (Exception exc)
                {
                    Logger.Info("Unhandled removing exception:");
                    Logger.Error(exc.StackTrace);
                }
            }

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("------------Сортировка по автору-------------");
            Console.WriteLine();

            service.SortBooksByTag(new CompareByAuthor());

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("--------------------Поиск--------------------");
            Console.WriteLine();

            var book = service.FindBookByTag(x => x.Author == "Джон Скит");

            Console.WriteLine(book);

            Console.WriteLine("--------------Сохранение/Загрузка------------");
            Console.WriteLine();

            service.SaveBooks(new BookListStorage("BookStorage"));
            service.LoadBooks(new BookListStorage("BookStorage"));

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("------------------Сериализация---------------");
            Console.WriteLine();

            service.SaveBooks(new BookListStorageSerialization("BookStorageSerialization"));
            service.LoadBooks(new BookListStorageSerialization("BookStorageSerialization"));

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("------------------Xml storage----------------");
            Console.WriteLine();

            service.SaveBooks(new BookListStorageXml("BookStorageXml"));
            //////////////////////////////////////////////////service.LoadBooks(new BookListStorageXML("BookStorageXml"));

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.ReadKey();
        }

        private class CompareByAuthor : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return string.Compare(x.Author, y.Author, StringComparison.Ordinal);
            }
        }
    }
}
