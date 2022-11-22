using HNZ9CU_HFT_2022231.Data;
using HNZ9CU_HFT_2022231.Logic;
using HNZ9CU_HFT_2022231.Models;
using HNZ9CU_HFT_2022231.Models.helperClasses;
using HNZ9CU_HFT_2022231.Repository;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace HNZ9CU_HFT_2022231.Test
{
    [TestFixture]
    public class Class1
    {
        BookLogic bookLogic;
        AuthorLogic authorLogic;
        PublisherLogic publisherLogic;

        [SetUp]
        public void Init()
        {
            var authorRep = new Mock<IAuthorRepository>();
            var bookRep = new Mock<IBookRepository>();
            var pubRep = new Mock<IPublisherRepository>();

            Book b1 = new Book() { Id = 1, Title = "Elveszett Bárka", Price = 1233, RelaseDate = 2007, PagenNumber = 120, Rating = 4.5, AuthorId = 1, PublisherId = 1 };
            Book b2 = new Book() { Id = 2, Title = "Utazás a Holdba", Price = 1643, RelaseDate = 1999, PagenNumber = 431, Rating = 2.2, AuthorId = 2, PublisherId = 2 };
            Book b3 = new Book() { Id = 3, Title = "Leleményes Hangya", Price = 2495, RelaseDate = 1951, PagenNumber = 152, Rating = 8.3, AuthorId = 3, PublisherId = 3 };

            Author a1 = new Author() { Id = 1, BirthDate = 1969, IsAlive = true, Country = "Russia", Name = "Ivan Ivinics" };
            Author a2 = new Author() { Id = 2, BirthDate = 1934, IsAlive = false, Country = "Hungary", Name = "Lajos Bárdos" };
            Author a3 = new Author() { Id = 3, BirthDate = 1950, IsAlive = false, Country = "Croatia", Name = "Luka Timoti" };

            Publisher p1 = new Publisher() { Id = 1, Name = "Best Books", City = "Budapest", Address = "Hungária krt. 44", EstablishDate = 2001, NumberOfPublishedBooks = 340, Rating = 3.7 };
            Publisher p2 = new Publisher() { Id = 2, Name = "Alexandro", City = "Szeged", Address = "Iskola utca 13", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2 };
            Publisher p3 = new Publisher() { Id = 3, Name = "Hipogrif Kiadó", City = "Budapest", Address = "Kálvin tér 36", EstablishDate = 2004, NumberOfPublishedBooks = 10, Rating = 2 };

            b1.Author = a1;
            b2.Author = a2;
            b3.Author = a3;

            b1.Publisher = p1;
            b2.Publisher = p2;
            b3.Publisher = p3;

            p1.Books = new List<Book>() { b1 };
            p2.Books = new List<Book>() { b2 };
            p3.Books = new List<Book>() { b3 };

            List<Book> Blist = new List<Book>{b1, b2, b3 };
            List<Author> Alist = new List<Author> { a1, a2, a3 };
            List<Publisher> Plist = new List<Publisher> { p1, p2, p3 };

            authorRep.Setup(x => x.ReadAll()).Returns(Alist.AsQueryable());
            bookRep.Setup(x => x.ReadAll()).Returns(Blist.AsQueryable());
            pubRep.Setup(x => x.ReadAll()).Returns(Plist.AsQueryable());

            bookLogic = new BookLogic(bookRep.Object);
            authorLogic = new AuthorLogic(authorRep.Object);
            publisherLogic = new PublisherLogic(pubRep.Object);

        }

        [Test]
        public void BookCreateTestInValid()
        {
            Assert.Throws<ArgumentException>(() => bookLogic.Create(new Book() { Id = 1, Title = "", Price = 1233, RelaseDate = 2007, PagenNumber = 120, Rating = 4.5, AuthorId = 1, PublisherId = 1 }));
        }

        [Test]
        public void AuthorCreateTestInValid()
        {
            Assert.Throws<ArgumentException>(() => authorLogic.Create(new Author() { Id = 1, BirthDate = 1969, IsAlive = true, Country = "Russia", Name = "" }));
        }

        [Test]
        public void PublisherCreateTestInValid()
        {
            Assert.Throws<ArgumentException>(() => publisherLogic.Create(new Publisher() { Id = 1, Name = "", City = "Budapest", Address = "Hungária krt. 44", EstablishDate = 2001, NumberOfPublishedBooks = 340, Rating = 3.7 }));
        }

        [Test]
        public void PublishersOfDeadWritersTest()
        {
            var ps = bookLogic.PublishersOfDeadWriters();
            var x = bookLogic.ReadAll();

            Assert.AreEqual(ps.First().Name, "Alexandro");
        }

        [Test]
        public void BestBooksInEveryPublisherTest()
        {
            var ps = publisherLogic.BestBooksInEveryPublisher();

            List<BestBooks> bb = new List<BestBooks>();

            foreach (var item in ps)
            {
                bb.Add(item);
            }

            Assert.AreEqual(bb[0].BestBookName, "Utazás a Holdba");
            Assert.AreEqual(bb[1].BestBookName, "Elveszett Bárka");
            Assert.AreEqual(bb[2].BestBookName, "Leleményes Hangya");
        }
    }
}
