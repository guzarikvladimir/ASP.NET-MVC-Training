using System;
using NLog;

namespace Task1.ConsoleUI
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            BookListService service;
            try
            {
                IBookRepository repository = new BookListStorage("BooksStorage.txt");
                service = new BookListService(repository);
            }
            catch (Exception exc)
            {
                logger.Info("Repository problem:");
                logger.Error(exc.StackTrace);

                return;
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------------Добавление---------------");
            Console.WriteLine("---------------------------------------------");

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
                    logger.Info("Adding element. Element exists in the collection:");
                    logger.Error(exc.StackTrace);
                }
                catch (Exception exc)
                {
                    logger.Info("Unhandled adding exception:");
                    logger.Error(exc.StackTrace);
                }
            }

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------------Удаление-----------------");
            Console.WriteLine("---------------------------------------------");

            var defBook = new Book();

            Book[] removingBooks = { book5, defBook };

            foreach (var variable in removingBooks)
            {
                try
                {

                    service.RemoveBook(variable);

                }
                catch (ArgumentException exc)
                {
                    logger.Info("Removing element. The element are not in the collection:");
                    logger.Error(exc.Message);
                    logger.Error(exc.Data);
                    logger.Error(exc.Source);
                    logger.Error(exc.TargetSite);
                    logger.Error(exc.StackTrace);
                }
                catch (Exception exc)
                {
                    logger.Info("Unhandled removing exception:");
                    logger.Error(exc.StackTrace);
                }
            }

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------------Сортировка---------------");
            Console.WriteLine("---------------------------------------------");

            service.SortBooksByTag(Tag.Name);

            foreach (var variable in service)
            {
                Console.WriteLine(variable);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------------Поиск--------------------");
            Console.WriteLine("---------------------------------------------");

            var book = service.FindBookByTag(Tag.Author, "Джон Скит");

            Console.WriteLine(book);

            Console.ReadKey();
        }
    }
}
