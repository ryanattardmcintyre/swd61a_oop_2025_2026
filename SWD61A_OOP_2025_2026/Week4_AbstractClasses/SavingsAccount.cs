using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses
{
    public class SavingsAccount: BankAccount
    {
        public double InterestRate { get; set; }

        public override double Withdraw(double amount)
        {
           if(Balance >= amount)
            {
                Balance -= amount;
            }

            return Balance;
        }
    }
}
