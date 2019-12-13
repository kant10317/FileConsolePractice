using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Workspace\其它練習\AR_R_OMA.20190612093026";

            Console.WriteLine(Path.GetFileName(path));

            if (!File.Exists(path))
            {
                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            // Open the stream and read it back.
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                Console.WriteLine("===OpenRead===");
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            Console.WriteLine("===ReadAllText===");
            string content = File.ReadAllText(path, Encoding.Default);
            Console.WriteLine(content);

            Console.WriteLine("===ReadAllLines===");
            string[] lines = File.ReadAllLines(path, Encoding.Default);
            var excludeEmptyLines = File.ReadAllLines(path, Encoding.Default).Where(c => !string.IsNullOrWhiteSpace(c));

            Console.ReadLine();
        }

    }
}
