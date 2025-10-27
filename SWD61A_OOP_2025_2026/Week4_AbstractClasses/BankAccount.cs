using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses
{
    /*
     * Abstract classes (Characteristics)
     * - abstract class BankAccount
     * - class cannot be instantiated - you cannot create an object 
     * - there to be inherited like an interface
     * - an abstract class can inherit an interface like a normal class
     * - notation: public abstract returntype MethodName(....);
     * - you can also additional properties
     * -
     * 
     * Abstract vs Interfaces (differences)
     * - An Abstract class can hold implemented methods/properties AND also ABSTRACT components
     * - an abstract class can have a PRIVATE constructor where to instantiate other objects
     * - You can also inherit from ONE abstract class but you can inherit from MULTIPLE interfaces
     * 
     */

    public abstract class BankAccount : IAccount, ILogTransactions
    {
        public double Balance { get; set; }
        public string Owner { get; set; }
        public string IBAN { get; set; }
        public List<string> Transactions { get; set; }

        public void AddTransaction(string transaction)
        {
            if (Transactions == null) Transactions = new List<string>();
            else Transactions.Add(transaction);
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            string transaction = $"{DateTime.Now} - Deposit - {amount} - new balance: {Balance}";
            AddTransaction(transaction); 
        }

        public abstract double Withdraw(double amount);
         
    }
}
