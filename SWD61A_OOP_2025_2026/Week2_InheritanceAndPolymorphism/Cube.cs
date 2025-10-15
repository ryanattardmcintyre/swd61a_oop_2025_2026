using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Cube : Square
    {
        public Cube() : base() {
            CanvasType = "3D";
        }
        public Cube(int x, int y, int z, double length) : base(x, y, length)
        {
            Z = z;
        }
        public override double FindArea()
        {
            return base.FindArea() * 6;
        }

        public virtual double FindVolume()
        {
            return Length * Length * Length;
        }
    }
}
