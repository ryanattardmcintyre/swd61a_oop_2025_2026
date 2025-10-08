using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Class: A class is a collection of related fields and methods that would compose or
      // design an entity e.g. Person, Catalog

namespace Week1_IntroToClassesAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Library related stuff:
            Library myLibrary = new Library(); //declaring and instantiating the Library class and object

            Book myBook1 = new Book();
            myBook1.Id = 1;
            myBook1.Title = "Test";
            myBook1.Price = 50;

            myLibrary.Add(myBook1);

            Console.WriteLine($"Library no. of books: {myLibrary.BookCount}");
            //Console.WriteLine("Library no. of books: " + myLibrary.BookCount);

            Console.ReadKey();


            // Basic Stuff:

            Book myBook = new Book();
            myBook.Stock = -100;



            Person p; //declare an object, syntax: <type> <object name>;
            p = new Person(); //creating an object in memory i.e we can start setting data inside

            //setting data into p
            p.Name = "Ryan";
            p.Surname = "Attard"; //Ryan Attard is being stored in an object of type Person
            p.Age = 20;
            //reading data from p

            int yearIWasBorn = DateTime.Now.Year - p.Age; //Datetime is a BUILT-IN class

            //read the data from screen and set it into p
            Console.WriteLine("Input your name"); //WriteLine displays what's inside the brackets on screen
            p.Name = Console.ReadLine(); //Console is a BUILT-IN class used to refer to the console application 
            //user has to hit ENTER here
            Console.WriteLine("Input your surname");
            p.Surname = Console.ReadLine();

            //read the data from p and shows it on screen
            Console.WriteLine("Full name: " + p.Name + " " + p.Surname);

            Console.ReadKey(); //It suspends the execution until any key is keyed in
                               //Reason we apply ReadKey at the end is to give the user enough time to view the feedback

        }
    }
}
