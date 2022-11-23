using ConsoleTools;
using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace HNZ9CU_HFT_2022231.Client
{
    public class Program
    {
        static void BookCreate(RestService rs)
        {
            Book newBook = new Book();

            string tit;
            do
            {
                Console.WriteLine("Give the book a new title!");
                tit = Console.ReadLine();
            } while (!(tit.Length > 3));
            newBook.Title = tit;

            int price;
            do
            {
                Console.WriteLine("Give the book a new price!");
                price = int.Parse(Console.ReadLine());
            } while (!(price > 0));
            newBook.Price = price;

            int Reld;
            do
            {
                Console.WriteLine("Give the book a new Relase Date!");
                Reld = int.Parse(Console.ReadLine());
            } while (!(Reld > 0));
            newBook.RelaseDate = Reld;

            int pn;
            do
            {
                Console.WriteLine("How many pages does the book has?");
                pn = int.Parse(Console.ReadLine());
            } while (!(pn > 0));
            newBook.PagenNumber = pn;

            double rate;
            do
            {
                Console.WriteLine("The book's rating?");
                rate = double.Parse(Console.ReadLine());
            } while (!(rate > 0));
            newBook.Rating = rate;

            int aid;
            do
            {
                Console.WriteLine("Give in the Author's ID of the book!");
                aid = int.Parse(Console.ReadLine());
            } while (!(aid > 0));
            newBook.AuthorId = aid;

            int pid;
            do
            {
                Console.WriteLine("Give in the Publisher's ID of the book!");
                pid = int.Parse(Console.ReadLine());
            } while (!(pid > 0));
            newBook.PublisherId = pid;

            rs.Post(newBook, "book");
            Console.WriteLine("Book added!");
        }
        static void BookReadAll(RestService rs)
        {
            Console.WriteLine("All books in the database: \n");
            var ra = rs.Get<Book>("book");
            ra.ForEach(b => Console.WriteLine($"Title: {b.Title}\t Author: {b.Author.Name} \t Publisher: {b.Publisher.Name} "));
            Console.WriteLine("\nPress any key to close window!");
            Console.ReadLine();
        }
        static void BookReadOne(RestService rs)
        {
            Console.WriteLine("Which book are you interested in? Give in an ID!");
            int bookid = int.Parse(Console.ReadLine());
            Book searched = rs.Get<Book>(bookid, "book");
            Console.WriteLine($"The searched book: Title: {searched.Title}, Writer's name: {searched.Author.Name}");
            Console.ReadLine();
        }
        static void BookUpdate(RestService rs)
        {
            Console.WriteLine("Which book do you want to update? Type ID:");
            int oldbookid = int.Parse(Console.ReadLine());

            Book newBook = new Book();

            int price;
            do
            {
                Console.WriteLine("Give the book a new price!");
                price = int.Parse(Console.ReadLine());
            } while (!(price > 0));
            newBook.Price = price;

            double rate;
            do
            {
                Console.WriteLine("The book's rating?");
                rate = double.Parse(Console.ReadLine());
            } while (!(rate > 0));
            newBook.Rating = rate;

            int pid;
            do
            {
                Console.WriteLine("Give in the Publisher's ID of the book!");
                pid = int.Parse(Console.ReadLine());
            } while (!(pid > 0));
            newBook.PublisherId = pid;


            rs.Put(newBook, $"book/{oldbookid}");
            Console.WriteLine("Updated!");
            Console.ReadLine();
        }
        static void BookDelete(RestService rs)
        {
            Console.WriteLine("Please type in the ID of the book you want to delete!");
            int id = Convert.ToInt32(Console.ReadLine());
            rs.Delete(id, "book");
            Console.WriteLine("Book deleted!");
            Console.ReadLine();
        }

        static void AuthorCreate(RestService rs)
        {
            Author newa = new Author();
            //rs.Post(newBook, "book");
            Console.WriteLine("Author added!");
        }
        static void AuthorReadAll(RestService rs)
        {
            Console.WriteLine("All authors in the database: \n");
            var ra = rs.Get<Author>("author");
            ra.ForEach(b => Console.WriteLine($"Name: {b.Name}\t BirthDate: {b.BirthDate}"));
            Console.WriteLine("\nPress any key to close window!");
            Console.ReadLine();
        }
        static void AuthorReadOne(RestService rs)
        {
            Console.WriteLine("Which author are you interested in? Give in an ID!");
            int id = int.Parse(Console.ReadLine());
            Author searched = rs.Get<Author>(id, "author");
            Console.WriteLine($"The searched author: Name: {searched.Name}, BirthDate: {searched.BirthDate}");
            Console.ReadLine();
        }
        static void AuthorUpdate(RestService rs)
        {
            Console.WriteLine("Updated!");
            Console.ReadLine();
        }
        static void AuthorDelete(RestService rs)
        {
            Console.WriteLine("Please type in the ID of the author you want to delete!");
            int id = int.Parse(Console.ReadLine());
            rs.Delete(id, "author");
            Console.WriteLine("Author removed!");
            Console.ReadLine();
        }

        static void PublisherCreate(RestService rs)
        {
            Publisher newPublisher = new Publisher();
            //rs.Post(newBook, "book");
            Console.WriteLine("Publisher added!");
        }
        static void PublisherReadAll(RestService rs)
        {
            Console.WriteLine("All Publishers in the database: \n");
            var ra = rs.Get<Publisher>("publisher");
            ra.ForEach(b => Console.WriteLine($"Name: {b.Name}\t Address: {b.Address}"));
            Console.WriteLine("\nPress any key to close window!");
            Console.ReadLine();
        }
        static void PublisherReadOne(RestService rs)
        {
            Console.WriteLine("Which publisher are you interested in? Give in an ID!");
            int id = int.Parse(Console.ReadLine());
            Publisher searched = rs.Get<Publisher>(id, "book");
            Console.WriteLine($"The searched publisher: Name: {searched.Name} Address: {searched.Address}");
            Console.ReadLine();
        }
        static void PublisherUpdate(RestService rs)
        {
            Console.WriteLine("Updated!");
            Console.ReadLine();
        }
        static void PublisherDelete(RestService rs)
        {
            Console.WriteLine("Please type in the ID of the publisher you want to delete!");
            int id = int.Parse(Console.ReadLine());
            rs.Delete(id, "publisher");
            Console.WriteLine("Publisher deleted!");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:19866/"); //endpoint name
            
            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List all books!", () => BookReadAll(rest))
                .Add("Create new book!", () => BookCreate(rest))
                .Add("Read One Book!", () => BookReadOne(rest))
                .Add("Update existing book!", () => BookUpdate(rest))
                .Add("Delete book!", () => BookDelete(rest))
                .Add("Back", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List all authors!", () => AuthorReadAll(rest))
                .Add("Create new author!", () => AuthorCreate(rest))
                .Add("Read One author!", () => AuthorReadOne(rest))
                .Add("Update existing author!", () => AuthorUpdate(rest))
                .Add("Delete author!", () => AuthorDelete(rest))
                .Add("Back", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List all publishers!", () => PublisherReadAll(rest))
                .Add("Create new publisher!", () => PublisherCreate(rest))
                .Add("Read One publisher!", () => PublisherReadOne(rest))
                .Add("Update existing publisher!", () => PublisherUpdate(rest))
                .Add("Delete publisher!", () => PublisherDelete(rest))
                .Add("Back", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
