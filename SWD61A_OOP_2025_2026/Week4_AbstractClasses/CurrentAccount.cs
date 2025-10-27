using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses
{
    public class CurrentAccount: BankAccount
    {
        public string ChequeBookNumber { get; set; }
        public BankAccount FallBackAccount { get; set; }

        public override double Withdraw(double amount)
        {
            //Balance = 1000;
            //Amount = 1001;
            //Fallback balance = 0;
            if (amount > Balance)
            {
                //there is not enough balance to allow withdrawal
                if (FallBackAccount != null)
                {
                    double difference = amount - Balance; //1001 - 1000 = 1
                    if (FallBackAccount.Balance >= difference) //
                    {
                        FallBackAccount.Withdraw(difference);
                        Balance = 0;
                        return Balance;
                    }
                    else
                    {
                        throw new Exception("Withdrawal is bounced back due to not enough balance");
                    }
                }
                else
                {
                    throw new Exception("Withdrawal is bounced back due to not enough balance");
                }
            }
            else
            {
                Balance -= amount;
                return Balance;
            }

        }
    }
}
