using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Composition is the strongest type of relationship between 2 classes which implies
//            that Class B cannot be instantiated unless Class A is first instantiated

//Aggregation is weaker than composition which implies that Class A can make use of 
//            Class B and stores Class B in any of its properties but there existence
//            does not depend on each other e.g. 
           // Example 1: Attendance - Student
           // Example 2: Group - Unit (1-many)

//Association is the weakest form of relationship which implies Class A can make use of
           // Class B i.e. Class A doesn't store an instance of Class B
           //e.g. Attendance and Person


namespace Week5_ClassRelationships.Aggregation
{
    public class Attendance: ICsv
    {
        public DateTime Timestamp { get; set; }
        public Unit Unit { get; set; }
        public Group Group { get; set; }
        public Attendance(DateTime? dateTaken, Unit unit, Group group)
        {
            if (dateTaken == null)
            {
                Timestamp = DateTime.Now;
            }
            else
            {
                Timestamp = dateTaken.Value;
            }
            Unit = unit;
            Group = group;

            PresentStudents = new List<Student>();
            AbsentStudents = new List<Student>();
        }

        protected List<Student> PresentStudents;
        protected List<Student> AbsentStudents;

        public void TakeAttendance(Student s, bool present, Person l)
        {
            if(l.GetRole() != "Lecturer") { return; }

            if(present)
            {
                PresentStudents.Add(s);
            }
            else
            {
                AbsentStudents.Add(s);
            }
        }

        public void ExportToCsv(string path)
        {
            string csvOutput = "";
           
            foreach(var s in PresentStudents)
            {
                csvOutput += $"{s.Id},{s.Name},p\n";
            }

           foreach (var s in AbsentStudents)
            {
                csvOutput += $"{s.Id},{s.Name},a\n";
            }


           System.IO.File.AppendAllText(path, csvOutput);
        }
    }
}
