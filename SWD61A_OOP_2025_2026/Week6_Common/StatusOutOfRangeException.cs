using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    public class StatusOutOfRangeException: Exception
    {
       
        public StatusOutOfRangeException(int lower, int upper): 
            base($"Status is out of range. Input from {lower} to {upper}")
        {
          
        }

        public StatusOutOfRangeException(string message): base(message) { }
        public StatusOutOfRangeException(string message, Exception inner) : base(message, inner) { }
    }
}
