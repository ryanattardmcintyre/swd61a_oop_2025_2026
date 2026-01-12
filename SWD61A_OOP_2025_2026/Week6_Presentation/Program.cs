using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;
using Week6_DataAccess;


namespace Week6_Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiation of classes (Which we are going to use in both methods)

            AttendanceDbContext db = new AttendanceDbContext(); //database abstraction/represents the database
            StudentsRepository studentsRepository = new StudentsRepository(db); //using this object to manage students'data
            GroupsRepository groupsRepository = new GroupsRepository(db);
            AttendancesRepository attendancesRepository = new AttendancesRepository(db);
            UnitsRepository unitsRepository = new UnitsRepository(db);
            StatusesRepository statusesRepository = new StatusesRepository(db);
            StatsRepository statsRepository = new StatsRepository(db);


            //--------------------------------------------------------------------------



            int mainMenuChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Main menu ============== ");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Units");
                Console.WriteLine("3. Groups");
                Console.WriteLine("4. Attendances");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Input your choice:");
                try //-must have
                {
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Letters are not allowed. Type numbers from 1 to 5");
                    mainMenuChoice = 5;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Number is out of range - still not acceptable. Type numbers from 1 to 5");
                    mainMenuChoice = 5;
                }
                catch (Exception) //for any unplanned exceptions -should have
                {
                    Console.WriteLine("An error has occurred. Type numbers from 1 to 5");
                    mainMenuChoice = 5;
                }
                finally //always runs //optional
                {
                    Console.WriteLine("Leaving the main menu...");
                }


                switch (mainMenuChoice)
                {
                    case 1:
                        StudentsMenu(studentsRepository, groupsRepository);
                        break;

                    case 4:
                        AttendancesMenu(attendancesRepository, 
                            studentsRepository, unitsRepository, 
                            groupsRepository, statusesRepository,
                            statsRepository);
                        break;

                    case 5:
                        Console.WriteLine("Press any key to terminate the application...");
                        break;
                }

                Console.ReadKey(); 

            } while (mainMenuChoice != 5);



        }

        //attendancesRepository, studentsRepository, unitsRepository, groupsRepository
        static void AttendancesMenu(AttendancesRepository attendancesRepository, 
            StudentsRepository studentsRepository, 
            UnitsRepository unitsRepository,
            GroupsRepository groupsRepository,
            StatusesRepository statusRepository, StatsRepository statsRepository)
        {
            int attendanceMenuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Attendance menu ============== ");
                Console.WriteLine("1. Take attendance");
                Console.WriteLine("2. List attendance for group & unit & day");
                Console.WriteLine("3. Display Absenteesim for student");
                
                Console.WriteLine("4. Display the surname and how many students have got that surname");
                Console.WriteLine("5. Display how many students there are per group");
                Console.WriteLine("6. Display monthly absenteeism and sort by the most missed month"); //Jan - 50%, Feb - 70%, Mar - 30%
                Console.WriteLine("7. Display monthly absenteeism for a specific student");
                
                Console.WriteLine("8. Find the Average absenteesim for a student.");
                Console.WriteLine("9. In which month the student missed the most?");

                Console.WriteLine("10. Top 2 present students");
                Console.WriteLine("11. Top 2 present students for group");
                Console.WriteLine("12. Top 2 present students for group within a date range");

                Console.WriteLine("13. List attendance for student");

                Console.WriteLine("Input choice");
                attendanceMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (attendanceMenuChoice) {
                    case 1:
                        try
                        {
                            //---------------------- asking the user choose group ------------------

                            Console.WriteLine();
                            Console.WriteLine("Id - Group");
                            Console.WriteLine("-----------------------");
                            int groupId = 0;
                            try
                            {
                                foreach (var group in groupsRepository.Get())
                                {
                                    Console.WriteLine($"{group.Id} - {group.Name}");
                                }

                                Console.WriteLine("Type in the group ID");
                                groupId = Convert.ToInt32(Console.ReadLine());
                            }

                           
                            catch (EntityException ex) //inner exceptions
                            {
                                string errorMessage = "Failed to connect with the database";
                                Console.WriteLine(errorMessage);

                                new Logging().Log(ex, errorMessage);

                                Console.ReadKey();
                                throw; //it will re-throw the exception generated
                            }
                            catch (FormatException) //inner exceptions
                            {
                                Console.WriteLine("Choose from the group ids displayed");
                                Console.ReadKey();
                                throw;
                            }
                            catch (Exception ex) //inner exceptions
                            {
                                Console.WriteLine("An error has occurred. We will investigate");
                                Console.ReadKey();
                                throw;
                            }



                            //---------------------- asking the user choose unit ------------------

                            Console.WriteLine();
                            Console.WriteLine("Id - Unit");
                            Console.WriteLine("-----------------------");
                            foreach (var unit in unitsRepository.Get())
                            {
                                Console.WriteLine($"{unit.Id} - {unit.Code} - {unit.Programme}");
                            }

                            Console.WriteLine("Type in the unit ID");
                            int unitId = Convert.ToInt32(Console.ReadLine());

                            //-------------------- taking the attendance for all students ---------

                            //1. implement statusesRepository
                            //2. get a list of students in selected group <- this has been done
                            //3. foreach student in list 

                            var listOfStudents = studentsRepository.GetByGroup(groupId);
                            List<Attendance> attendanceList = new List<Attendance>();
                            foreach (var student in listOfStudents)
                            {
                                //3a show details of student
                                Console.WriteLine($"{student.Id} - {student.Name} {student.Surname}");
                                //3b display the statuses on screen like in Units and Groups
                                Console.WriteLine($"Choose the right status by inputting the id next to it");
                                foreach (var status in statusRepository.Get())
                                {
                                    Console.Write($"{status.Id} - {status.Name} | ");
                                }

                                //3c ask for the input
                                int statusForStudent = Convert.ToInt32(Console.ReadLine());

                                //3d record the attendance record in a temp list
                                attendanceList.Add(new Attendance()
                                {
                                    StatusFK = statusForStudent,
                                    StudentFK = student.Id,
                                    UnitFK = unitId
                                });
                            }

                            //3e after the loop call the TakeAttendance(List...)
                            try
                            {
                                attendancesRepository.TakeAttendances(attendanceList);
                                Console.WriteLine("Attendance saved!! Press any button to go back to the Attendances menu...");
                            }
                            catch (StatusOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                           
                            Console.ReadKey();
                        }
                        catch (Exception) //outer exception
                        {
                            Console.WriteLine("Error handled. Press a key to continue");
                            Console.ReadKey();
                        }

                        break;


                    case 2:
                        //listing of attendances by group, day, and unit
                        //---------------------- asking the user choose group ------------------
                        Console.WriteLine();
                        Console.WriteLine("Id - Group");
                        Console.WriteLine("-----------------------");
                        foreach (var group in groupsRepository.Get())
                        {
                            Console.WriteLine($"{group.Id} - {group.Name}");
                        }

                        Console.WriteLine("Type in the group ID");
                        int groupIdFor2 = Convert.ToInt32(Console.ReadLine());

                        //---------------------- asking the user choose unit ------------------

                        Console.WriteLine();
                        Console.WriteLine("Id - Unit");
                        Console.WriteLine("-----------------------");
                        foreach (var unit in unitsRepository.Get())
                        {
                            Console.WriteLine($"{unit.Id} - {unit.Code} - {unit.Programme}");
                        }

                        Console.WriteLine("Type in the unit ID");
                        int unitIdFor2 = Convert.ToInt32(Console.ReadLine());

                        //----------------------- date ----------------------------------


                        Console.WriteLine("Input the day");
                        int day = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input the month");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input the year");
                        int year = Convert.ToInt32(Console.ReadLine());

                        DateTime forgedDate1 = new DateTime(year, month, day);
                        DateTime forgedDate2 = new DateTime(year, month, day, 23,59,59);


                        //--------------------- start the search -------------------------

                        var listOfStudentsFor2 = studentsRepository.GetByGroup(groupIdFor2);
                        
                        foreach(var student in listOfStudentsFor2)
                        {
                            var a =attendancesRepository.GetAttendance(student.Id, forgedDate1, forgedDate2, unitIdFor2).
                            FirstOrDefault();
                            if(a != null)
                                Console.WriteLine($"{a.DateTaken.ToString("dd/MM/yyyy HH:mm")} " +
                                    $"- {a.FullName}, {a.GroupName}, {a.UnitName} - {a.Status}");
                        
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();

                        break;


                    case 3:
                        Console.WriteLine("Input the student id");
                        int studentFor3 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(" Absent % " + statsRepository.GetAbsenteesim(studentFor3));
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 4:
                        var list = statsRepository.GetSurnameStats();
                        
                        foreach(var row in list)
                        {
                            Console.WriteLine($"{row.Surname} - {row.Count}");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 5:
                        var list2 = statsRepository.GetGroupStats();

                        foreach (var row in list2)
                        {
                            Console.WriteLine($"{row.GroupName} - {row.Count}");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 6:
                        var list3 = statsRepository.GetMonthlyAbsenteeisms();

                        foreach (var row in list3)
                        {
                            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt16(row.Month))}" +
                                $" - {row.Year}"+
                                $" - {Math.Round(row.Abseentisim,2)}%");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 7:

                        Console.WriteLine("Input student id");
                        var selectedStudentId = Convert.ToInt32(Console.ReadLine());

                        var list4 = statsRepository.GetMonthlyAbsenteeismsForStudent(selectedStudentId);

                        foreach (var row in list4)
                        {
                            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt16(row.Month))}" +
                                $" - {row.Year}" +
                                $" - {Math.Round(row.Abseentisim, 2)}%");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.WriteLine("Input student id");
                        var selectedStudentIdForTask8 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Avg absenteesim for student is " +
                               statsRepository.GetAvgMonthlyAbsenteeismsForStudent(selectedStudentIdForTask8));
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                    case 9:
                        Console.WriteLine("Input student id");
                        var selectedStudentIdForTask9 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Top monthly absenteesim for student is " +
                               statsRepository.GetTopMonthlyAbsenteeismsForStudent(selectedStudentIdForTask9));

                        var allDetails = statsRepository.GetTopMonthlyAbsenteeismsForStudentAllValues(selectedStudentIdForTask9);
                        Console.WriteLine($"Month: {allDetails.Month}, Year: {allDetails.Year}, Absenteeism: {allDetails.Abseentisim}");

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                 case 10:

                        var listOfStudents10 = statsRepository.GetTop2PresentStudents();

                        foreach(var student in listOfStudents10)
                        {
                            Console.WriteLine($"{student.Name} {student.Surname}");
                        }

                        Console.WriteLine("Press a key to continue...");
                        Console.ReadKey();
                        break;

                }

            } while (attendanceMenuChoice != 999);
        }



        static void StudentsMenu(StudentsRepository studentsRepository, GroupsRepository groupsRepository)
        {
            int studentMenuChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Student menu ============== ");
                Console.WriteLine("1. List all students");
                Console.WriteLine("2. List students by group");
                Console.WriteLine("3. Search for student");
                Console.WriteLine("4. Add");
                Console.WriteLine("5. Update");
                Console.WriteLine("6. Delete");

                Console.WriteLine("10. Go back to the main menu");
                Console.WriteLine("Input your choice:");
                studentMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (studentMenuChoice)
                {
                    case 1:

                        var list = studentsRepository.Get();

                        foreach(var student in list)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 2:

                        //ask the user to input the group name
                        Console.WriteLine("Input the group name");
                        string inputGroupName = Console.ReadLine();

                        //var list = studentsRepository.GetByGroupName(...)
                        var list2 = studentsRepository.GetByGroup(inputGroupName);

                        //display the list of students returned from the above line

                        foreach (var student in list2)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 3:
                        //ask the user to input the group name
                        Console.WriteLine("Input keyword");
                        string inputKeyword = Console.ReadLine();

                        //var list = studentsRepository.GetByGroupName(...)
                        var list3 = studentsRepository.Get(inputKeyword);

                        //display the list of students returned from the above line

                        foreach (var student in list3)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();


                        break;

                    case 4:
                        Student myNewStudent = new Student();

                        Console.WriteLine("Type in the student's name");
                        myNewStudent.Name = Console.ReadLine();

                        Console.WriteLine("Type in the student's surname");
                        myNewStudent.Surname = Console.ReadLine();

                        Console.WriteLine("Type in the student's idcard");
                        myNewStudent.IdCard = Console.ReadLine();

                        Console.WriteLine("Type in the student's phone");
                        myNewStudent.Phone = Console.ReadLine();

                        Console.WriteLine("Type in the student's email");
                        myNewStudent.Email = Console.ReadLine();


                        Console.WriteLine();
                        Console.WriteLine("Id - Group");
                        Console.WriteLine("-----------------------");
                        foreach(var group in groupsRepository.Get())
                        {
                            Console.WriteLine($"{group.Id} - {group.Name}");
                        }
                        
                        Console.WriteLine("Type in the student's group ID");
                        myNewStudent.GroupFK = Convert.ToInt32(Console.ReadLine());

                        studentsRepository.Add(myNewStudent);
                       
                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;


                    case 5:
                        Console.WriteLine("Write down the id of the student that needs updating");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Student studentToUpdate = new Student();
                        studentToUpdate.Id = studentId;
                      
                        Console.WriteLine("Type in the student's name");
                        studentToUpdate.Name = Console.ReadLine();

                        Console.WriteLine("Type in the student's surname");
                        studentToUpdate.Surname = Console.ReadLine();

                        Console.WriteLine("Type in the student's idcard");
                        studentToUpdate.IdCard = Console.ReadLine();

                        Console.WriteLine("Type in the student's phone");
                        studentToUpdate.Phone = Console.ReadLine();

                        Console.WriteLine("Type in the student's email");
                        studentToUpdate.Email = Console.ReadLine();


                        Console.WriteLine();
                        Console.WriteLine("Id - Group");
                        Console.WriteLine("-----------------------");
                        foreach (var group in groupsRepository.Get())
                        {
                            Console.WriteLine($"{group.Id} - {group.Name}");
                        }

                        Console.WriteLine("Type in the student's group ID");
                        studentToUpdate.GroupFK = Convert.ToInt32(Console.ReadLine());


                        studentsRepository.Update(studentToUpdate);

                        Console.WriteLine("Update successfull! " +
                            "Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 6:
                        Console.WriteLine("Write down the id of the student that needs to be deleted");
                        int studentToBeDeletedId = Convert.ToInt32(Console.ReadLine());
                        studentsRepository.Delete(studentToBeDeletedId);
                        
                        Console.WriteLine("Delete successfull! " +
                            "Click any button to return back to Students Menu...");
                        Console.ReadKey();


                        break;



                    case 10:
                        Console.WriteLine("Press any key to go back to the main menu...");
                        break;
                }

                

            } while (studentMenuChoice != 10);

        }


    }
}


