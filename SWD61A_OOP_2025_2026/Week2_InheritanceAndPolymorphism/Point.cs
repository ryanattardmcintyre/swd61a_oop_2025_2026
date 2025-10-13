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
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Color Color { get; set; }
        public string Id { get; set; }  

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

    }
}
