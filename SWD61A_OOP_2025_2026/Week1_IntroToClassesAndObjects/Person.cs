using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClassesAndObjects
{

    //1. class names: 
    //1.1   use Pascal case - first letter capital form then lower case
    //1.2   do not use symbols and numbers or spaces in class names
    //1.3   singular form!

    //2. properties:
    //2.1   Properties are "normally" public
    //2.2   properties use Pascal case 
    //2.3   Properties have getters and setters
    //2.4   Properties are considered to be the attributes that describe the class
    //2.5   Properties are used to store or fetch the data

    public class Person
    {
        public int Id { get; set; }
        public string IdCardNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName
        {
            get {
                return Name + " " + Surname;

            }
        }
        public int Age { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public DateTime Dob { get; set; }


    }
}
