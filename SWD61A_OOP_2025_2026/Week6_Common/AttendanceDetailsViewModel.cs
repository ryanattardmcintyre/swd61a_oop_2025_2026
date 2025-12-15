using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    //A view model class, is a class created to cater for the UI
    //the data here is what the end-user will see - not foreign key
    //the data here will be populated from different tables
    public class AttendanceDetailsViewModel
    {
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime DateTaken { get; set; }
        public string GroupName { get; set; }
        public string UnitName { get; set; }
    }
}
