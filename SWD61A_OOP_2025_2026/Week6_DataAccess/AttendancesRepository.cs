using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class AttendancesRepository
    {
        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public AttendancesRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Attendance> Get()
        {
            return _context.Attendances;
        }

        public void TakeAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public void TakeAttendances(List<Attendance> attendances) 
        {
            var dateTaken = DateTime.Now;
            foreach (var attendance in attendances)
            {
                attendance.DatePlaced = dateTaken;
                TakeAttendance (attendance);
            }
        }
        
        public AttendanceDetailsViewModel GetAttendance(int id, DateTime dateTaken)
        {
            //with the use of ViewModels "classes" we can construct objects
            //on-the-fly to return data in a clear/neat way to be presented on the screen

            //...so the front end developer doesn't need to make multiple database calls/requests
            //to obtain the e.g. student full name, group name , ....


            //Select * From Attendances
            //Where Student.Id = id and Attendance.DatePlaced = datetaken

            var oneAttendance = (from attendance in _context.Attendances
                                 where attendance.StudentFK ==id && 
                                 attendance.DatePlaced == dateTaken
                                 orderby attendance.Student.Name ascending
                                 select new AttendanceDetailsViewModel()
                                   {
                                       DateTaken = attendance.DatePlaced,
                                       FullName = attendance.Student.Name + ' ' + attendance.Student.Surname,
                                       GroupName = attendance.Student.Group.Name,
                                       UnitName = attendance.Unit.Code,
                                       Status = attendance.Status.Name
                                   }).FirstOrDefault();

            return oneAttendance;

            

        }

        public IQueryable<AttendanceDetailsViewModel> GetAttendance(int studentId, 
            DateTime startDate, DateTime endDate)
        {
            var list = (from attendance in _context.Attendances
                        where attendance.StudentFK == studentId
                        && attendance.DatePlaced >= startDate &&
                        attendance.DatePlaced <= endDate
                        orderby attendance.Student.Name ascending
                        select new AttendanceDetailsViewModel()
                        {
                            DateTaken = attendance.DatePlaced,
                            FullName = attendance.Student.Name + ' ' + attendance.Student.Surname,
                            GroupName = attendance.Student.Group.Name,
                            UnitName = attendance.Unit.Code,
                            Status = attendance.Status.Name
                        });

            return list;
        }


        }
}
