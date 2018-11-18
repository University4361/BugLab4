using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vir_exe_lab4
{
    class Program
    {
        private const string _publicFolderPath = "C:\\Users\\Lavrov\\Desktop\\Test";
        private const string _privateFolderPath = "C:\\Users\\Lavrov\\Desktop\\Test1";

        static void Main(string[] args)
        {

            using (File.Create(Path.Combine(_publicFolderPath, "VyVzlomany.txt")))
            { }

            File.WriteAllText(Path.Combine(_publicFolderPath, "VyVzlomany.txt"), "LOOOOL");

            string path = Process.GetCurrentProcess().MainModule.FileName.Split('\\').LastOrDefault().Split('.').FirstOrDefault() + ".txt";

            Process.Start("notepad.exe", Path.Combine(_privateFolderPath, path));
        }
    }
}
