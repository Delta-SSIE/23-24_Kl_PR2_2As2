using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class FileLogger : ILogger
    {
        private StreamWriter _sw;
        public FileLogger(string filename)
        {
            _sw = new StreamWriter(filename);
        }

        ~FileLogger()
        {
            _sw.Close();
        }

        public void Log(string message)
        {
            _sw.WriteLine(message);
        }
    }
}
