using System;
using System.IO;

namespace Bestanden
{
    class Program
    {
        static void Main(string[] args)
        {
            // InstanceDemo();

            ReadAll("C:");
        }

        private static void ReadAll(string drive)
        {
            DriveInfo di = new DriveInfo(drive);
            Console.WriteLine($"Drive: {di.Name}");
            ShowDir(di.RootDirectory);
        }

        private static void ShowDir(DirectoryInfo dir)
        {
            Console.WriteLine(dir.FullName);
            foreach(DirectoryInfo sub in dir.GetDirectories())
            {
                try
                {
                    ShowDir(sub);
                }
                catch
                {

                }
            }
            foreach(FileInfo file in dir.GetFiles())
            {
                Console.WriteLine(file.FullName);
            }
        }

        private static void InstanceDemo()
        {
            FileInfo file = new FileInfo(@"D:\Blaat.txt");

            if (file.Exists)
            {
                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Attributes);
                Console.WriteLine(file.DirectoryName);
                file.Delete();
            }
            else
            {
                file.Create().Close();
            }
        }
    }
}
