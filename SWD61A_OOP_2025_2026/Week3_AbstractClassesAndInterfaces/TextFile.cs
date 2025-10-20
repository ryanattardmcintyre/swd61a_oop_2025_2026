using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week3_AbstractClassesAndInterfaces
{
    /// <summary>
    /// This class will be representing a .txt file
    /// </summary>
    public class TextFile : IFileHandler<string>
    {
        public int Size { get; set; }
        public string Filename { get; set; }
        public DateTime LastUpdated { get; set; }

        public void Delete(string path)
        {
            if(File.Exists(path)==true)
            {
                File.Delete(path);
            }
        }

        public string Read(string path)
        {
            if (File.Exists(path) == true)
            {
                return File.ReadAllText(path);
            }
            else
            {
                return "";
            }
        }

        public void Write(string path, string data)
        {
            /*   if (File.Exists(path) == true)
               {
                   string existentText = Read(path);
                   File.WriteAllText(path, existentText + data);
               }
               else
               {
                   using (var file = File.CreateText(path))
                   {
                       file.Write(data);
                   }
               }
            */

            /*using (var file = File.App(path))
            {
                file.Write(data);
            }
            */

            File.AppendAllText(path, data);
        }

        public void Write(string path, string data, bool overwrite)
        {
            if (overwrite)
            {
                File.WriteAllText(path, data);
            }
            else
            {
                Write(path, data);
            }
        }
    }
}
