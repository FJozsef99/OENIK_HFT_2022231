using ConsoleTools;
using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HNZ9CU_HFT_2022231.Client
{
    public class Program
    {
        #region book crud
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
                rate = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); //6.7 = 6,7
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
        }
        static void BookDelete(RestService rs)
        {
            Console.WriteLine("Please type in the ID of the book you want to delete!");
            int id = Convert.ToInt32(Console.ReadLine());
            rs.Delete(id, "book");
            Console.WriteLine("Book deleted!");
        }
        #endregion

        #region author crud

        static void AuthorCreate(RestService rs)
        {
            Author newa = new Author();

            string name;
            do
            {
                Console.WriteLine("Give the new author a name!");
                name = Console.ReadLine();
            } while (!(name.Length > 3));
            newa.Name = name;

            int bd;
            do
            {
                Console.WriteLine("Give the new author a birth date!");
                bd = int.Parse(Console.ReadLine());
            } while (!(bd > 0));
            newa.BirthDate = bd;

            char a;
            do
            {
                Console.WriteLine("Is she/he alive? (y/n)");
                a = char.Parse(Console.ReadLine());
            } while (!(a == 'y' || a == 'n'));
            if(a == 'y')
                newa.IsAlive = true;
            else
                newa.IsAlive = false;

            string country;
            do
            {
                Console.WriteLine("Wher is she/he from?");
                country = Console.ReadLine();
            } while (!(country.Length > 0));
            newa.Country = country;

            rs.Post(newa, "author");

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
            Console.WriteLine("Which author do you want to update? Type ID:");
            int oldautid = int.Parse(Console.ReadLine());

            Author a = new Author();

            char alive;
            do
            {
                Console.WriteLine("Is the author alive? (y/n)");
                alive = char.Parse(Console.ReadLine());
            } while (!(alive == 'y' || alive == 'n'));
            if (alive == 'y')
                a.IsAlive = true;
            else
                a.IsAlive = false;

            string country;
            do
            {
                Console.WriteLine("Give in the new country name!");
                country = Console.ReadLine();

            } while (country.Length > 0);

            rs.Put(a, $"author/{oldautid}");
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
        #endregion

        #region pulisher crud

        static void PublisherCreate(RestService rs)
        {
            Publisher newPublisher = new Publisher();

            string name;
            do
            {
                Console.WriteLine("Give the new publisher a name!");
                name = Console.ReadLine();
            } while (!(name.Length > 3));
            newPublisher.Name = name;

            int date;
            do
            {
                Console.WriteLine("Estabilish date of the new publisher:");
                date = int.Parse(Console.ReadLine());
            } while (!(date > 0));
            newPublisher.EstablishDate = date;

            string cit;
            do
            {
                Console.WriteLine("Where is the new publisher located!");
                cit = Console.ReadLine();
            } while (!(cit.Length > 0));
            newPublisher.City = cit;

            string add;
            do
            {
                Console.WriteLine("What is the new publisher's address?");
                add = Console.ReadLine();
            } while (!(add.Length > 0));
            newPublisher.Address = add;

            double rat;
            do
            {
                Console.WriteLine("Rating of the new publisher: ");
                rat = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); //6.7 = 6,7
            } while (!(rat > 0));
            newPublisher.Rating = rat;

            int sum;
            do
            {
                Console.WriteLine("How many books are published by the new publisher?");
                sum = int.Parse(Console.ReadLine());
            } while (!(sum >= 0));
            newPublisher.NumberOfPublishedBooks = sum;


            rs.Post(newPublisher, "publisher");

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
            Publisher searched = rs.Get<Publisher>(id, "publisher");
            Console.WriteLine($"The searched publisher: Name: {searched.Name} Address: {searched.Address}");
            Console.ReadLine();
        }
        static void PublisherUpdate(RestService rs)
        {
            Console.WriteLine("Which publisher do you want to update? Type ID:");
            int oldpubid = int.Parse(Console.ReadLine());

            Publisher p = new Publisher();

            string cit;
            do
            {
                Console.WriteLine("Where is the publisher located?");
                cit = Console.ReadLine();
            } while (!(cit.Length > 0));
            p.City = cit;

            string add;
            do
            {
                Console.WriteLine("What is the publisher's addresss?");
                add = Console.ReadLine();
            } while (!(add.Length > 0));
            p.Address = add;

            double rat;
            do
            {
                Console.WriteLine("New rating of the publisher: ");
                rat = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); //6.7 = 6,7
            } while (!(rat > 0));
            p.Rating = rat;

            int sum;
            do
            {
                Console.WriteLine("What is the publisher's number of published books?");
                sum = int.Parse(Console.ReadLine());
            } while (!(sum > 0));
            p.NumberOfPublishedBooks = sum;


            rs.Put(p, $"publisher/{oldpubid}");

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
        #endregion

        #region non crud methods
        static void PublishersOfDeadWriters(RestService rs)
        {
            List<PubName> pubNames = rs.Get<PubName>("/pubsOfDeadWriters");
            pubNames.ForEach(c => Console.WriteLine("Publishers of dead writers: " + c.Name));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }

        static void CheapBooks(RestService rs)
        {
            List<CheapBook> cheaps = rs.Get<CheapBook>("/CheapBooks");
            cheaps.ForEach(c => Console.WriteLine($"Title: {c.BookTitle}, Price: {c.BookPrice}, Publisher: {c.PublisherName}"));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }

        static void GoodHunDeadWriters(RestService rs)
        {
            List<DeadBookWithRating> l = rs.Get<DeadBookWithRating>("/GoodDeadHun");
            l.ForEach(x => Console.WriteLine($"Name: {x.BookWriterName}, AvgRating: {x.AvgRating}, Writer's Birth Date: {x.WritersBirthDate}"));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }

        static void AliveVeteranExpensiveWriters(RestService rs)
        {
            List<VeteranExpensiveWriters> l = rs.Get<VeteranExpensiveWriters>("/VetWriters");
            l.ForEach(x => Console.WriteLine($"Name: {x.WriterName}, SumPrice Of books: {x.BooksSumPrice}, Writer's Birth Date: {x.WritersBirthDate}"));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }

        static void BestBooksInEveryPublisher(RestService rs)
        {
            List<BestBooks> l = rs.Get<BestBooks>("/pubsBestBooks");
            l.ForEach(x => Console.WriteLine($"Publisher name: {x.PublisherName}, Book's title: {x.BestBookName}, Book's rating: {x.BookRating}"));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }

        static void PubAndBooksGoodRating(RestService rs)
        {
            List<GoodPublisher> l = rs.Get<GoodPublisher>("/GoodRatings");
            l.ForEach(x => Console.WriteLine($"Publisher name: {x.PublisherName}, AvgRating: {x.OverAllRating}"));
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadLine();
        }
        #endregion


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

            var noncruds = new ConsoleMenu(args, level: 1)
                .Add("PublishersOfDeadWriters", () => PublishersOfDeadWriters(rest))
                .Add("CheapBooks", () => CheapBooks(rest))
                .Add("GoodHunDeadWriters", () => GoodHunDeadWriters(rest))
                .Add("AliveVeteranExpensiveWriters", () => AliveVeteranExpensiveWriters(rest))
                .Add("BestBooksInEveryPublisher", () => BestBooksInEveryPublisher(rest))
                .Add("PubAndBooksGoodRating", () => PubAndBooksGoodRating(rest))
                .Add("Back", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Non Crud Methods", () => noncruds.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
