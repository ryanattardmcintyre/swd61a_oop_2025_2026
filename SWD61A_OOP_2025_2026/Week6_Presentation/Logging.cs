using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Presentation
{
    public class Logging
    {
        public void Log(Exception ex, string message)
        {
            System.IO.File.WriteAllText("logs.log", 
                DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ", custom message: " +  message
                + " generated message " + ex.Message);
        }
    }
}
