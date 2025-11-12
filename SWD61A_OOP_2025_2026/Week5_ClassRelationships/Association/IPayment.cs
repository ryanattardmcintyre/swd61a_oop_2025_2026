using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public interface IPayment
    {
        DateTime BoughtOn { get; set; }
        double Buy(Seat s); //returns the total amount resulting from applied or no promotion;
    }
}
