using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses
{
    public interface ILogTransactions
    {
        //property
        List<string> Transactions { get; set; }

        //method:
        void AddTransaction(string transaction);

    }
}
