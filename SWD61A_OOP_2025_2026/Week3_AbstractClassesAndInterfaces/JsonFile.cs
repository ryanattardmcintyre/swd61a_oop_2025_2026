using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Week3_AbstractClassesAndInterfaces
{

    //NOT ALLOWED : public class Circle : Point, Square

    /// <summary>
    /// This represents a .json file
    /// 
    /// </summary>
    public class JsonFile : IFileHandler<object>, ILog
    {
        public int Size { get; set; }
        public string Filename { get; set; }
        public DateTime LastUpdated { get; set; }

        public void Delete(string path)
        {
            if (File.Exists(path) == true)
            {
                File.Delete(path);
            }
        }

        public void Log(string message)
        {
            File.AppendAllText("myJsonLog.log",DateTime.Now.ToString()+' '+ message+'\n');
        }
        public object Read(string path)
        {
            Log("About to deserialize object from json file");
            dynamic obj = JsonConvert.DeserializeObject<object>(File.ReadAllText(path));
            Log("Read the object successfully");
            Log("Deserialized the object successfully");

            Log($"Object read: {obj.ToString()}");


            return obj;
        }
        public void Write(string path, object data)
        {
            string str = File.ReadAllText(path);
            string serializedData = JsonConvert.SerializeObject(data);
            str += serializedData;
            File.WriteAllText(path, str);
        }
        public void Write(string path, object data, bool overwrite)
        {
            if(overwrite)
            {
                string serializedData = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, serializedData);
            }
        }
    }
}
