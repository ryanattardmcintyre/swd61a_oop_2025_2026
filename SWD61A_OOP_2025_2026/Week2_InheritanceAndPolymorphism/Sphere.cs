using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Sphere: Cube
    {
        public override double FindArea()
        {
            return 4 * Math.PI * (Length / 2) * (Length / 2);
        }

        public override double FindVolume()
        {
            return (4 * (Math.PI * (Length / 2) * (Length / 2) * (Length / 2))) / 3;
        }
    }
}
