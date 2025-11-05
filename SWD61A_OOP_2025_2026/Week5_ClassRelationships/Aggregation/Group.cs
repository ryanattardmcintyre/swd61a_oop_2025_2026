using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public class Group
    {
        public string Id { get; set; } //SWD61A
        public int Year { get; set; } //2026
        public List<Unit> Units { get; set; }

        public Group()
        { 
            Units = new List<Unit>(); //instantiating the list so i can add units
        }

        public void AddUnit(Unit u)
            { Units.Add(u); }
    }
}
