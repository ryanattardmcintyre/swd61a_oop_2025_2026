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
            List<Point> myShapes = new List<Point>();


            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 15;

            p1.Color = Color.Blue;
            p1.Id = "Point 1";

            Console.WriteLine(p1.Describe());


            Square s1 = new Square();
            s1.X = 20;
            s1.Y = 25;
            s1.Color = Color.Green;
            s1.Id = "Square 1";

            Console.WriteLine(s1.Describe());


            Console.ReadKey();
        }
    }
}
