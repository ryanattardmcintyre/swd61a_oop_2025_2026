using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public abstract string GetRole();

    }
}
