using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class StatsRepository
    {
        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public StatsRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        //Display the absenteeism percentage for student
        public double GetAbsenteesim(int studentId)
        {

            var absenteeism = from a in _context.Attendances
                              where a.StudentFK == studentId
                              group a by a.StudentFK into cluster
                              select
                                  ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count()*1.0)) * 100);

            //list = 10


            var percentage = absenteeism.FirstOrDefault();
            return percentage;
        }
    }
}
