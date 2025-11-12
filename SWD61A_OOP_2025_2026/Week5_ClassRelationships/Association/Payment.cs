using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public abstract class Payment : IPayment
    {

        protected Payment()
        {
            Tax = 0.18; //vat
        }
        public DateTime BoughtOn { get; set; }

        public double Tax { get; set; }

        public abstract double Buy(Seat s);
         
    }
}
