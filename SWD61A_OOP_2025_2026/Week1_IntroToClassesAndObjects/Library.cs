using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClassesAndObjects
{
    //private - keeps the component private/accessible to the "parent" component they're in
    //public - makes the component accessible from everywhere
    //protected - makes the component accessible only from derived/inherited classes
    //internal - makes the class accessible within the same namespace/project -
    //           it makes the component slighlty more restrictive than public
    public class Library
    {
        //constructor: it constructs instances, it initializes fields, variables, ...
        //             its like a method BUT it bears the same name as the class and it has no return types
        //             it runs FIRST
        public Library() { 
            books = new List<Book>(); //instantiation of/initialization of list of books
        }


        private List<Book> books; //field with a data type List that will hold only Book
                                  //fields use camel case i.e first letter is lowercase

        public int BookCount {  get { return books.Count; } }
        public void Add(Book book)
        {
           if (books != null) //meaning has the list been instantiated
           {
                if (book.Id == 0)
                { //do not allow addition of book
                    throw new Exception("Book Id has not been set"); 
                    //you have to make sure that this is caught and handled gracefully
                }
                else
                {
                    books.Add(book);
                }
           }
        }

        public void Remove(int id)
        {
            if(books!=null)
            {
                //for, while, do-while, foreach
                Book bookToDelete = null; //declaring a variable/local field hence the notation is camelCase
                foreach(Book b in books)
                {
                    if(b.Id == id)
                    {
                        //if you delete b straight away that might destroy the loop mechanism
                        bookToDelete = b;
                        break; //stops the loop
                    }
                }

                if(bookToDelete != null) //was the book to delete found in the list?
                { 
                    books.Remove(bookToDelete);
                }
            }
        }


        /// <summary>
        /// This method is going to deduct a copy from the stock we have and returns the total price to be paid
        /// by the customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public double Buy(int id, int qty)
        {
            //1. find the book
            if (books != null)
            {
                //for, while, do-while, foreach
                foreach (Book b in books)
                {
                    if (b.Id == id)
                    { //2. if its not null, deduct the stock 
                        b.Stock -= qty; //Stock = Stock -qty

                        //3. compute the total price //4. return the price
                        return qty * b.Price;
                    }
                }
            }
            return 0;
        }



    }
}
