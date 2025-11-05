using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public class Student : Person
    {
        public override string GetRole()
        {
            return "Student";
        }
    }
}
