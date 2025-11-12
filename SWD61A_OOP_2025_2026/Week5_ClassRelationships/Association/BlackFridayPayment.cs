using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class BlackFridayPayment : Payment
    {
        public BlackFridayPayment(): base()
        {
            DiscountPercentage = 0.2; //20%
        }
        public double DiscountPercentage { get; set; }
        public override double Buy(Seat s)
        {
           return (s.Price * (1 - DiscountPercentage)) * (1 + Tax);
        }
    }
}
