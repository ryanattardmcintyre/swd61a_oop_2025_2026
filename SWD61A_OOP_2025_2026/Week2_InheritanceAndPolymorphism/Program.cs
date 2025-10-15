using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
             

            List<Square> myShapes = new List<Square>();

            string menuChoice = "";
            do {
                Console.Clear(); //clears screen
                Console.WriteLine("1. Add Square");
                Console.WriteLine("2. Add Cube");
                Console.WriteLine("3. Find Area");
                Console.WriteLine("4. Find Volume");
                Console.WriteLine("5. Quit");

                Console.WriteLine("Input menu choice");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        //Adding a square

                        Console.WriteLine("Input Length of square");
                        Square s = new Square() { Length = Convert.ToDouble(Console.ReadLine()) }; //a new notation
                        myShapes.Add(s);

                        Console.WriteLine("Square has been added. " + s.ToString());
                        break;

                    case "2":
                        //Add a cube

                        Console.WriteLine("Input Length of cube");
                        Cube c = new Cube() { Length = Convert.ToDouble(Console.ReadLine()) }; //a new notation
                        myShapes.Add(c); //<<<<<<<<<<<<<<<<<<<< since Cube inherits from Square we can add both types into same list

                        Console.WriteLine("Cube has been added. " + c.ToString());
                        break;

                    case "3":
                        //Find area
                        Console.WriteLine("Finding the areas of the following shapes");
                        foreach(var sq  in myShapes)
                        {
                            Console.WriteLine($"Area of a {sq.GetType().Name}: {sq.FindArea()}");
                            //Due to polymorphism the CLR will call the right FindArea on the object being called
                            //i.e. if its a square it calls FindArea of a square, if its a cube it will call FindArea of a cube
                        }

                        Console.WriteLine("All areas computed. Press a key to continue");
                        break;

                    case "4":
                        //Find volume
                        Console.WriteLine("Finding the volumes of the following shapes");
                        foreach (Square sq in myShapes)
                        {
                            if (sq.GetType() == typeof(Cube))
                            {
                                Cube cube = (Cube)sq; //typecasting 
                                Console.WriteLine($"Volume of a {sq.GetType().Name}: {cube.FindVolume()}");
                            }
                            //Due to polymorphism the CLR will call the right FindArea on the object being called
                            //i.e. if its a square it calls FindArea of a square, if its a cube it will call FindArea of a cube
                        }

                        Console.WriteLine("All areas computed. Press a key to continue");

                        break;
                }

                Console.WriteLine("Press a key to get to the main menu..."); 
                Console.ReadKey();

            } while (menuChoice != "5");




            Console.ReadKey();
        }
    }
}
