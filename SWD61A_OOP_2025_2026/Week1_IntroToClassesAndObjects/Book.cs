using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClassesAndObjects //logical grouping of things e.g. grouping of Book, Genre, Person, Program, etc
{
   //predefined set of values
    public enum Genre { Science, Marketing, Children, Maths, IT }                                                  
    //so when this will be consumed, the developer
                                                                 //has to select from these values only!
    //access modifiers:
    //public: makes the class accessible (usable/consumable) from anywhere
    //private : makes the property unusable from outside the class
    //protected : explaining this when we cover inheritance
    //internal: it makes the class accesible only within the namespace/project
    public class Book
    {
        //fields
        //fields are private
        //fields hold raw data
        private int stock; //private <data type> <name in camel case>;
        private int publishedYear;

        //properties (attributes or members of a class)
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int PublishedYear
        {
            get { return publishedYear; }
            set
            {
                if (value < DateTime.Now.Year) 
                    publishedYear = value;
                else
                    publishedYear = DateTime.Now.Year; //we cannot allow 2026, 2027,...
            }
        }
        public Genre Genre { get; set; }
        public bool Available
        {
            get { if (Stock > 0) return true; else return false; }
        }

        public int Stock //we re using the property to CONTROL access to the value
        {
            get { 
                return stock; //returning the value contained in the field stock
            }
            set //setting a non-negative value if what's being passed is < 0
            {
                if (value < 0) { stock = 0; }
                else stock = value; //its a built-in keyword/reserved word which holds the value passed into the property
            }
        }
        public double Price { get; set; }

        //methods

        //<access modifier> <return type> <name of method> ([<parameter1>,<parameter2>,...])
        public int ReOrderStock(int amount)  
        {
            if(amount > 0)
            {
                Stock += amount; //Stock = Stock + amount
            }

            return Stock; //return the newly updated Stock
        }

    }
}
