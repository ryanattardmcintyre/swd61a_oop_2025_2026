using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClassesAndInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IFileHandler<object>> myList = new List<IFileHandler<object>>();

            IFileHandler<object> myJsonFile = new JsonFile();
            dynamic myObj =  myJsonFile.Read("myjsonfile.json");
            Console.WriteLine(myObj.ToString());
            Console.WriteLine($"{myObj.Id}, {myObj.Name}");


            //var myObj = new { Id = 1, Name = "Ryan" } ;
            //myJsonFile.Write("myjsonfile.json", myObj, true);

            IFileHandler<string> myTextFile = new TextFile();
            string readString = myTextFile.Read("myTextfile.txt");
            Console.WriteLine(readString);

            //myTextFile.Write("myTextfile.txt", "hello world");



            Console.ReadKey();

        }
    }
}
