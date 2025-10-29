using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition.Example1
{
    public class Building: IPlot
    {

        public int Number { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double PlotSize { get; set; }
        public List<Room> Rooms { get; set; }

        public double CalculateTotalArea(int levels)
        {
            return PlotSize * levels;
        }

        public void Plot(string path)
        {
            string plotDescripton = "";
            foreach (Room room in Rooms)
            {
                plotDescripton += $"Room {room.Number}, {room.Label} with area {room.Area}\n";
            }

            System.IO.File.WriteAllText(path, plotDescripton);
        }
    }
}
