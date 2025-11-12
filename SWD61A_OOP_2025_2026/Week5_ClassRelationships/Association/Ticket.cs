using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class Ticket
    {
        public Event Event { get; set; }
        public Seat Seat { get; set; }

        public User User { get; set; }
        public Ticket(Event e, Seat s, User u)
        {
            Seat = s;
            Event = e;
            User = u;
        }

        //1. Relationship between Ticket and Payment is the weakest one : Association
        //2. Association: Class a is being used by Class b BUT not store it in any of the attributes inside
        //3. (Strongest) Composition -> Aggregation -> Association (Weakest)
        public void SellTicket(Payment payment)
        {
            Console.WriteLine("You need to pay this amount " + payment.Buy(Seat));
            //once payment is successfully
            //...we mark the seat as taken
        }


    }
}
