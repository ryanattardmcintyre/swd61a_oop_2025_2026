using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime DateHappening { get; set; }

        public List<Seat> Seats {get;set;}

    }
}
