using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week4_AbstractClasses
{
    public class TermAccount : BankAccount
    {
        public DateTime MaturityDate { get; set; }
        public double InterestRates { get; set; }
        public int Years { get; set; }

        public override double Withdraw(double amount)
        {
            if(DateTime.Now < MaturityDate)
            { throw new Exception("Maturity date has not been reached yet; You cannot withdraw"); }
            else
            {
                double accumulatedInterest = 0;
                for (int i = 0; i < Years; i++)
                {
                    accumulatedInterest += ((InterestRates / 100) * (Balance + accumulatedInterest));
                }
                return Balance + accumulatedInterest;

            }
        }
    }
}
