using System;
using System.Linq;
using ExerciseDelegates.Entities;
using LearningDelegates.Entities;

namespace ExerciseDelegates {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("---------EXERCÍCIO LIVROS---------");
            List<Book> books = new List<Book>();
            books.Add(new Book("Os Lusíadas", "Luís de Camões", 37.00));
            books.Add(new Book("O Hobbit", "j. r. r Tolkien", 65.0));
            books.Add(new Book("Dom Quixote", "Miguel de Cervantes", 38.0));
            books.Add(new Book("A Arte da Guerra", "Sun Tzu", 47.0));

            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            Func<Book, string> func = p => p.Title + " - " + p.Author.ToUpper() + " - R$" + p.Price.ToString("F2");
            List<string> result = books.Select(func).ToList();
            Console.WriteLine("All Books:");
            foreach (string resultItem in result) {
                Console.WriteLine(resultItem);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("After removing: ");

            books.RemoveAll(RemoveBook);//Calling Function
            books.RemoveAll(p => p.Price <= 38);//Lambda in-Line
            foreach (Book book in books) {
                Console.WriteLine(book);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("After increasing: ");

            Action<Book> action = IncreaseBooks;
            Action<Book> action2 = p => p.Price *= 1.1;
            books.ForEach(action);//Action without Lambda
            books.ForEach(action2);//Lambda
            books.ForEach(p => p.Price *= 1.1);//Lambda in-Line

            foreach (Book book in books) {
                Console.WriteLine(book);
            }
            Console.WriteLine("---------EXERCÍCIO PRODUTOS---------");
            Console.WriteLine("All Products: ");
            Func<Product, string> func1 = p => p.Name.ToUpper() + ", R$" + p.Price.ToString("F2");
            List<string> resultado = list.Select(func1).ToList();
            foreach (string resultadoItem in resultado) {
                Console.WriteLine(resultadoItem);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("After removing: ");

            list.RemoveAll(p => p.Price > 899);//Lambda in-Line
            list.RemoveAll(RemoveProduct);
            foreach (Product product in list) {
                Console.WriteLine(product);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("After increasing: ");

            Action<Product> actionProduct = IncreaseProduct;//Calling Function
            Action<Product> actionProduct2 = p => { p.Price *= 1.1; };//Lambda
            list.ForEach(actionProduct2);
            list.ForEach(actionProduct);
            list.ForEach(p => p.Price *= 1.1);//Lambda in-Line

            foreach(Product product in list) {
                Console.WriteLine(product);
            }
        }
        static bool RemoveBook(Book book) {
            return book.Price < 38;
        }
        static void IncreaseBooks(Book book) {
            book.Price *= 1.1;
        }
        static bool RemoveProduct(Product product) {
            return product.Price > 100.0;
        }
        static void IncreaseProduct(Product product) {
            product.Price *= 1.1;
        }

    }
}