using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Cylinder: Sphere
    {
        public Cylinder(): base() { }

        public Cylinder (int x, int y, int z, double diameter, double height):
            base(x,y,z,diameter)
        {
            Height = height;
        }
        public double Height { get; set; }
        public override double FindVolume()
        {
            return Math.PI * Math.Pow(Length / 2, 2) * Height;
        }

        public override double FindArea()
        {
            return (Math.PI * Math.Pow(Length / 2, 2) * 2) + (( Math.PI * (Length)) * Height);
        }
    }
}
