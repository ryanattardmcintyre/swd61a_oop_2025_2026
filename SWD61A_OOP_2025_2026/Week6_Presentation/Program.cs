using System;
using System.Collections.Generic;
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
                mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1:
                        StudentsMenu(studentsRepository, groupsRepository);
                        break;

                    case 4:
                        AttendancesMenu(attendancesRepository, studentsRepository, unitsRepository, groupsRepository);
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
            GroupsRepository groupsRepository)
        {
            int attendanceMenuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Attendance menu ============== ");
                Console.WriteLine("1. Take attendance");
                Console.WriteLine("2. List attendance for student");
                Console.WriteLine("3. Display Absenteesim for student");
                Console.WriteLine("4. Top 5 present students");
                Console.WriteLine("5. Top 5 present students for group");
                Console.WriteLine("6. Top 5 present studetns for group within a date range");

                Console.WriteLine("Input choice");
                attendanceMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (attendanceMenuChoice) {
                    case 1:

                        //---------------------- asking the user choose group ------------------
                        Console.WriteLine();
                        Console.WriteLine("Id - Group");
                        Console.WriteLine("-----------------------");
                        foreach (var group in groupsRepository.Get())
                        {
                            Console.WriteLine($"{group.Id} - {group.Name}");
                        }

                        Console.WriteLine("Type in the group ID");
                        int groupId = Convert.ToInt32(Console.ReadLine());

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
                        //3a show details of student
                        //3b display the statuses on screen like in Units and Groups
                        //3c ask for the input
                        //3d record the attendance record in a temp list
                        //3e after the loop call the TakeAttendance(List...)



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


