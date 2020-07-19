using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RecoverMP3Cailum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter directory containing ransomed files:");
            string directory = Console.ReadLine().Replace("\"", "");
            string[] files = Directory.GetFiles(directory);
            foreach (string fileName in files)
            {
                if (fileName.Contains(".[helprecover@foxmail.com].help"))
                {
                    string outputFileName = fileName.Substring(0, fileName.Length - ".id[60944A1B-2275].[helprecover@foxmail.com].help".Length);
                    if (!File.Exists(outputFileName))
                    {
                        Console.Write("fixing " + fileName + "... ");
                        try
                        {
                            using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                            {
                                bw.Write(File.ReadAllBytes(fileName).Skip(40000).ToArray());
                            }
                            Console.WriteLine("done");
                        }
                        catch
                        {
                            Console.WriteLine("ERROR - processing failed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("file " + fileName + " has already been fixed");
                    }
                }
            }
            Console.WriteLine("\nprocessing complete");
            Console.ReadLine();
        }
    }
}
