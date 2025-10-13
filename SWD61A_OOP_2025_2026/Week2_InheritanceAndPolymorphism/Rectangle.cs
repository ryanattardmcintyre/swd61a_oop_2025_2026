using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Rectangle: Square
    {
        public int Width { get; set; }

        public override double FindArea()
        {
            return Length * Width;
        }
    }
}
