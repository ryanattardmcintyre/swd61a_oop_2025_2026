using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Circle: Square
    {
        public override string Describe()
        {
            return $"Circle: {Id} at ({X}, {Y}) of color {Color.Name} also of diameter {Length}";
        }

        public override void Draw(Graphics g)
        {
            Pen p = new Pen(Color);

            g.DrawEllipse(p, X, Y, (float)Length, (float)Length);
        }


        public override double FindArea()
        {
            return Math.PI * Math.Pow((Length)/2, 2);
        }
    }
   
}
