using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition.Example1
{
    public class Reception: Room
    {
        public bool ReceptionDesk;
        public Reception(Building b): base(b)
        {
            Label = "Foyer";
        }

        private bool emergencyExit;

        protected override int GetNumberOfApertures()
        {
            if (emergencyExit) { return 5; }
            return 4;
        }
    }
}
