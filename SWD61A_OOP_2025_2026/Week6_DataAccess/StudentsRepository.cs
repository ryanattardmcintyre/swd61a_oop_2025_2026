using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common; //namespace holding the abstraction of the database

namespace Week6_DataAccess
{
    public class StudentsRepository
    {
        //AttendanceDbContext is an abstraction of the database
        // i.e. an object representing the external database
        // the object is the instantation of a class called AttendanceDbContext
        // holiding defintions of tables and their columns
        // and their constraints

        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public StudentsRepository(AttendanceDbContext context) 
        {
            _context = context;
        }

        //CRUD methods that we need to implement to assist us in managing 
        //Students' data

        /// <summary>
        /// Getting the entire list of students from the database
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> Get() {
            return _context.Students.OrderBy(s=>s.Name);
        }

        //Built-in with EntityFramework / EntityFrameworkCore 
        //LINQ-to-Entities
        public IQueryable<Student> Get(string filter)
        {
            //lambda expression

            return Get().Where(s => s.Name.StartsWith(filter));

            //a filter on the entire list of students is being applied
            //filter has a condition where if Name of student
            //student is represented with x
            //...starts with filter
            //when condition is met it will return only those records.

            /*
             * var list = Get();
             * List<Student> myFilteredStudents = new List<Student>();
             * foreach (var s in list)
             * {
             *      if(s.Name.StartsWith(filter))
             *          myFilteredStudents.Add(s);
             * }
             * return myFilteredStudents;
             * 
             */ 
        
        }

        public IQueryable<Student> GetByGroup(int groupId)
        {
            return Get().Where(s => s.GroupFK == groupId);
        
        }

        public IQueryable<Student> GetByGroup(string groupName)
        {
            //Appreciate that in the following querying method
            //we are accessing a property within the Groups table
            // from a student instance by means of a NAVIGATIONAL PROPERTY
            // automatically created called Group

            return Get().Where(s => s.Group.Name.Contains(groupName)
             || s.Group.Name.StartsWith(groupName));
        }


        public Student Get(int id) {
        
            return Get().FirstOrDefault(s=> s.Id == id);
        }
    }
}
