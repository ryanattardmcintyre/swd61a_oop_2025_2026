using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses
{
    public interface IAccount
    {
        //property
        double Balance { get; set; }
        string Owner { get; set; }

        //method
        void Deposit(double amount);
        double Withdraw(double amount);

    }
}
