using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5_ClassRelationships.Composition.Example1;

namespace Week5_ClassRelationships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Composition/ composite type of relationship

            Room myKitchen = new Room();



            Building myHouse = new Building();
            myHouse.Number = 1;
            myHouse.City = "Valletta";
            myHouse.Address = "Republic street";

            Room myBedroom = new Room(myHouse);
            myBedroom.Area = 10;
            myBedroom.Label = "Master Bedroom";




        }
    }
}
