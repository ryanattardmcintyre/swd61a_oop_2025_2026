using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClassesAndInterfaces
{
    //What is an interface?
    //-An interface is a collection of method signatures
    //-It can be used like a contract - therefore any method signatures declared
    // here and the interface is implemented/inherited, these methods are forced to be implemented
    // in the client class
    //-Thus no implementations are done in an interface
    //-An interface can act as a base type
    //-A class can inherit many interfaces NOT just one!

    public interface IFileHandler<t>
    {
        int Size { get; set; }
        string Filename { get; set; }
        DateTime LastUpdated { get; set; }

        t Read(string path);
        void Write(string path, t data);
        void Write(string path, t data, bool overwrite);
        void Delete(string path);
    }
}
