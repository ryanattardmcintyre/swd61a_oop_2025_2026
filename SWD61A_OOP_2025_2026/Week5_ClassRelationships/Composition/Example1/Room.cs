using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition.Example1
{
    public class Room
    {
        public int Number { get; set; }
        public string Label { get; set; }
        public double Area { get; set; }
        public bool Occupied { get; set; }

        public Building Building { get; set; }
        public Room(Building b)
        {
            Building = b;
        }

        protected virtual int GetNumberOfApertures()
        { return 1; }

    }
}
