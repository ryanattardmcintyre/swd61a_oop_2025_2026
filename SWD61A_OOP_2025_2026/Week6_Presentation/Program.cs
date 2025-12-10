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

                    case 5:
                        Console.WriteLine("Press any key to terminate the application...");
                        break;
                }

                Console.ReadKey(); 

            } while (mainMenuChoice != 5);



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
                        break;

                    case 6:
                        break;



                    case 10:
                        Console.WriteLine("Press any key to go back to the main menu...");
                        break;
                }

                

            } while (studentMenuChoice != 10);

        }


    }
}


