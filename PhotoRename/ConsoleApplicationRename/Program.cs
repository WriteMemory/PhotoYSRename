using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplicationRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = System.IO.Directory.GetCurrentDirectory();
            GetDirectory(currentPath);
            Console.WriteLine("文件重命名处理完毕。");
            Console.ReadKey();
        }
        static void GetDirectory(string path)
        {
            SetDirectoryFilename(path);
            foreach (var dir in Directory.GetDirectories(path))
            {
                GetDirectory(dir);
            }
        }
        static void SetDirectoryFilename(string dirPath)
        {
            //Console.WriteLine(dirPath);
            string[] files = Directory.GetFiles(dirPath, "*_ys.*");
            foreach (var item in files)
            {
                string afterName = item.Remove(item.LastIndexOf("_ys"), 3);
                //Console.WriteLine(afterName);
                Console.WriteLine(item);
                File.Delete(afterName);
                File.Move(item, afterName);
            }
        }
    }
}
