using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Cube : Square
    {
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
