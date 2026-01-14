using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
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

            //3 records for student 1
            //2 of which the student was absent (status absent = 2)
            // (2/3) * 100%

            var absenteeism = from attendance in _context.Attendances //foreach (var attendance in _context.Attendances)...
                              where attendance.StudentFK == studentId //evaluating only attendances for studentId
                              group attendance by attendance.StudentFK into cluster 
                              //use group when you need to output a single (calculated) value from all your rows within a group
                              select
                                  ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count()*1.0)) * 100);

            //list = 10


            var percentage = absenteeism.FirstOrDefault();
            return percentage;
        }

        //"4. Display the surname and how many students have got that surname"
        //Attard - 2
        //Zammit - 1
        //Vella - 1
        public List<SurnameCountViewModel> GetSurnameStats()
        {
            var list = from s in _context.Students
                       group s by s.Surname into cluster
                       orderby cluster.Count() descending
                       select new SurnameCountViewModel() //selecting while creating instances of the view model
                       {
                           Surname = cluster.Key, //key will contain the value which we are grouping by
                           Count = cluster.Count()
                       };

            return list.ToList();

            /*
            return _context.Students.GroupBy(x => x.Surname).OrderByDescending(x => x.Count())
                .Select(x => new SurnameCountViewModel() { Count = x.Count(), Surname = x.Key }).ToList();
            */
        }

        //Group - Count
        //SWD61A - 3
        //SWD61B - 1

        public List<GroupCountViewModel> GetGroupStats()
        {
            var list = from s in _context.Students
                       group s by s.Group.Name into cluster
                       orderby cluster.Count() descending
                       select new GroupCountViewModel() //selecting while creating instances of the view model
                       {
                           GroupName = cluster.Key, //key will contain the value which we are grouping by
                           Count = cluster.Count()
                       };

            return list.ToList();
        }

        //Display monthly absenteeism and sort by the most missed month
        //Feb - 60%
        //Jan - 50%

        public List<MonthlyAbsenteeismViewModel> GetMonthlyAbsenteeisms()
        {
            var list = from a in _context.Attendances
                       group a by new
                       {
                           a.DatePlaced.Month,
                           a.DatePlaced.Year
                       } into cluster
                       select new MonthlyAbsenteeismViewModel()
                       {
                            Month = cluster.Key.Month.ToString() ,
                           //Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cluster.Key.Month)
                           Year = cluster.Key.Year,
                           Abseentisim = ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100)
                       };
            return list.ToList();
        }


        /*
         *            Absenteeism ratio
         * Dec 2025 = 100%
         * Jan 2026 = 0%
         */ 
        public List<MonthlyAbsenteeismViewModel> GetMonthlyAbsenteeismsForStudent(int studentId)
        {
            var list = from a in _context.Attendances
                       where a.StudentFK == studentId
                       group a by new
                       {
                           a.DatePlaced.Month,
                           a.DatePlaced.Year
                       } into cluster
                       select new MonthlyAbsenteeismViewModel()
                       {
                           Month = cluster.Key.Month.ToString(),
                           //Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cluster.Key.Month)
                           Year = cluster.Key.Year,
                           Abseentisim = ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100)
                       };
            return list.ToList();
        }
        /*
         *              Console.WriteLine("8. Find the Average absenteesim for a student.");
                Console.WriteLine("9. In which month the student missed the most?");
        */

        public double GetAvgMonthlyAbsenteeismsForStudent(int studentId)
        {
            var list = from a in _context.Attendances
                       where a.StudentFK == studentId
                       group a by new
                       {
                           a.DatePlaced.Month,
                           a.DatePlaced.Year
                       } into cluster
                       select  new MonthlyAbsenteeismViewModel()
                       {
                           Month = cluster.Key.Month.ToString(),
                           //Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cluster.Key.Month)
                           Year = cluster.Key.Year,
                           Abseentisim = ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100)
                       }                       ;

            var result = list.Average(x => x.Abseentisim); //inside the Average method we
                                                           //specify the column of which we would to find the average of

            return result;
        }

        public double GetTopMonthlyAbsenteeismsForStudent(int studentId)
        {
            var list = from a in _context.Attendances
                       where a.StudentFK == studentId
                       group a by new
                       {
                           a.DatePlaced.Month,
                           a.DatePlaced.Year
                       } into cluster
                       select new MonthlyAbsenteeismViewModel()
                       {
                           Month = cluster.Key.Month.ToString(),
                           //Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cluster.Key.Month)
                           Year = cluster.Key.Year,
                           Abseentisim = ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100)
                       };

            var result = list.Max(x => x.Abseentisim); //inside the Max method we
                                                           //specify the column which we're going to use to get the max 
                                                           //value of

            return result;
        }

        public MonthlyAbsenteeismViewModel GetTopMonthlyAbsenteeismsForStudentAllValues(int studentId)
        {
            var list = from a in _context.Attendances
                       where a.StudentFK == studentId
                       group a by new
                       {
                           a.DatePlaced.Month,
                           a.DatePlaced.Year
                       } into cluster
                       orderby ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100) descending
                       select new MonthlyAbsenteeismViewModel()
                       {
                           Month = cluster.Key.Month.ToString(),
                           //Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cluster.Key.Month)
                           Year = cluster.Key.Year,
                           Abseentisim = ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100)
                       };

            return list.FirstOrDefault();
        }


        /*     Console.WriteLine("10. Top 2 present students");
                Console.WriteLine("11. Top 2 present students for group");
                Console.WriteLine("12. Top 2 present students for group within a date range");
        */

        public List<Student> GetTop2PresentStudents()
        {
            //tips:
            //1. always start your linq methods with var list = from ...
            //2. continue with the where (if you need)
            //3. continue with the group ... by
            //4. order by if you need
            //5. always end your linq block of code with select
            //6. cluster.Key will always give you back the column value which you grouped with
            //7. you can verify what type you're getting in the end by hovering on the var list (from no 1)

            var list = (from a in _context.Attendances
                       group a by a.Student into cluster
                       orderby ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100) ascending
                       select cluster.Key).Take(2);

            return list.ToList(); //sql: Select top 2
        }

        public List<Student> GetTop2PresentStudentsForGroup(int groupId)
        {
            //tips:
            //1. always start your linq methods with var list = from ...
            //2. continue with the where (if you need)
            //3. continue with the group ... by
            //4. order by if you need
            //5. always end your linq block of code with select
            //6. cluster.Key will always give you back the column value which you grouped with
            //7. you can verify what type you're getting in the end by hovering on the var list (from no 1)

            var list = (from a in _context.Attendances
                        where a.Student.GroupFK == groupId
                        group a by a.Student into cluster
                        orderby ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100) ascending
                        select cluster.Key).Take(2);

            return list.ToList(); //sql: Select top 2
        }

        public List<Student> GetTop2PresentStudentsForGroup(int groupId, DateTime fromDate, DateTime toDate)
        {
            //tips:
            //1. always start your linq methods with var list = from ...
            //2. continue with the where (if you need)
            //3. continue with the group ... by
            //4. order by if you need
            //5. always end your linq block of code with select
            //6. cluster.Key will always give you back the column value which you grouped with
            //7. you can verify what type you're getting in the end by hovering on the var list (from no 1)

            var list = (from a in _context.Attendances
                        where a.Student.GroupFK == groupId && 
                              a.DatePlaced >= fromDate && a.DatePlaced <= toDate
                        group a by a.Student into cluster
                        orderby ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100) ascending
                        select cluster.Key).Take(2);

            return list.ToList(); //sql: Select top 2
        }


        //Task: return the student which had the most absenteeism

        public Student GetStudentWithMostAbsenteeism()
        {
            var myTopStudent = (from a in _context.Attendances
                                group a by a.Student into cluster
                                orderby ((cluster.Where(x => x.StatusFK == 2).Count() / (cluster.Count() * 1.0)) * 100) descending
                                select cluster.Key).FirstOrDefault();

            return myTopStudent;
        }


    }
}
