using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition.Example1
{
    public class ComputerLab: Room
    {
        public ComputerLab(Building b):
            base(b)
        { }

        protected override int GetNumberOfApertures()
        {
            return 2;
        }
    }
}
