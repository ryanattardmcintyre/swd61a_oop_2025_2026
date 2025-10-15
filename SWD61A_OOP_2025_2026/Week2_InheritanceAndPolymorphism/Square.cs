using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{

    //Inheritance being applied. Notation used is the : next to the name of the class
    //Square inherits/derives from Point
    //This implies that Square is going to inherit all public & protected properites/methods
    //Advantages:
    //1) it saves you the time from having to type extra code
    //2) Square can be considered to be a Point.  List<Point>


    //object <- Point <- Square <- Rectangle
    //object <- Point <- Square <- Circle
    //in object you can find base methods like Equals(...), GetHashCode(), ToString()


    //Virtual - Override 
    //When in base classes you have methods that you want them to run differently in inherited
    //classes we mark them with virtual (in the base class)
    //In the inherited class we can then OVERRIDE the implementation, however maintaining the
    //same method signature

    public class Square: Point
    {
        //constructor
        public Square():base() //default constructor - you're trusing the consumer to set the properties at a later stage
        {
        }

        //non-default constructor -  you're forcing the consumer to assign the parameters immediately
        public Square(int x, int y, double length) : base(x,y) //calling the base (i.e. Point) constructor to pass x,y
        {
            Length = length;
        }

        //property
       public double Length { get; set; }

        public override string Describe()
        {
            //return base.Describe(); its going to run the Describe () of the base class (Point)
            return  $"Square: {Id} at ({X}, {Y}) of color {Color.Name} also of side {Length}";
        }

        public override void Draw(Graphics g)
        {
           Pen p = new Pen(Color); //Color is a property declared in Point BUT since we are inherint from Point we can still
                                   //access Color
           
            //Convert.ToXXXXXX
            //float.Parse()
            //typecasting (float) XXXX 
            g.DrawRectangle(p, X, Y, (float) Length, (float) Length);
        }

  

        //Task: Implement FindArea in all shapes
        //Task 2:
        //Create three additional classes
        //1) Cube
        //2) Sphere
        //3) Cylinder
        //4) Cone

        //In each of these add a Z coordinate 
        //Foreach of these classes implement FindArea() & FindVolume()

        //Your extra job is to find the class from which you will be inheriting from

        public virtual double FindArea()
        {
            return Length * Length;
        }
    }
}
