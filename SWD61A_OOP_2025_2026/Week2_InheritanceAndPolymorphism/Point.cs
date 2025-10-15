using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Point
    {
        //constructor: no return type + same class name
        public Point() //default
        {
            CanvasType = "2D";
        }

        public Point(int x, int y) //non-default - it has parameters
        {
            X = x;
            Y = y;
        }

        public Point(int x, int y, Color color)
        {
            X = x; Y = y;
            Color = color;
        }


        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Color Color { get; set; }
        public string Id { get; set; }

        protected string CanvasType; //its protected anything outside this class


        //Graphics is a built-in class which allows the developer to draw shapes on canvas
        //It is in the System.Drawing namespace/library
        public virtual void Draw(Graphics g)
        {
            Pen p = new Pen(Color);
            g.DrawLine(p, X, Y, X, Y);
        }
        public virtual string Describe()
        {
            return $"Point {Id} at ({X}, {Y}) of color {Color.Name}";
        }
        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode()) return true;
            else return false;

        }
        public override int GetHashCode()
        {
            //GetType = Point
            string uniqueId = X + "" + Y + "" + Id+""+this.GetType().Name;
            return uniqueId.GetHashCode();
        }
        public override string ToString() 
        {
            return Describe();
        }

    }
}
