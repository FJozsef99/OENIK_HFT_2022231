using ConsoleTools;
using HNZ9CU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HNZ9CU_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;
        static void List(string s)
        {
            Console.WriteLine(s + " List");
            Console.ReadLine();
        }
        static void Create(string s)
        {
            Console.WriteLine(s + " Create");
            Console.ReadLine();
        }
        static void Delete(string s)
        {
            Console.WriteLine(s + " Delete");
            Console.ReadLine();
        }
        static void Update(string s)
        {
            Console.WriteLine(s + " Update");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:19866/"); //endpoint name
            
            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Books"))
                .Add("Create", () => Create("Books"))
                .Add("Delete", () => Delete("Books"))
                .Add("Update", () => Update("Books"))
                .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
