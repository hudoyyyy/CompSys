using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Laba1KS
{
    class Program
    {
        static void Main(string[] args)
        {

            const string directory = @"C:\Texts\Fathencr.txt";
            //const string unzip = @"D:\UnZip\tale.zip"; 
            MethodEntr(directory);
            

            /*DirectoryInfo directorySelected = new DirectoryInfo(directory);
            MethodZip(directory, directorySelected);*/
            
        }
        static void MethodZip(string directory, DirectoryInfo directorySelected)
        {

            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                        FileInfo info = new FileInfo(directory + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                        Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                    }
                }
            }
        }
        static void MethodEntr(string directory)
        {
            int total = 0;
            int i = 0;
            byte kel = 1;
            double probab = 0.0;
            double enthrophOne = 0.0;
            double enthrophTotal = 0.0;
            double hint = 0.0;
            string load = "";
            Dictionary<char, int> openWith = new Dictionary<char, int> ();
            using (var obj = new StreamReader(directory))
            {
                
                while (i > -1)
                {
                    i = obj.Read();
                    if (i == -1) { break; }
                    total++;
                    if (!openWith.ContainsKey(Convert.ToChar(i)))
                    {
                        openWith.Add(Convert.ToChar(i), 1);
                    }
                    else
                    {
                        openWith[Convert.ToChar(i)] += 1;
                    }
                }
               
                foreach (KeyValuePair<char, int> keyValue in openWith)
                {
                    probab = Convert.ToDouble(Convert.ToDouble(keyValue.Value) / Convert.ToDouble(total));
                    enthrophOne = Convert.ToDouble(probab * Math.Log(1.0 / probab, 2));

                    enthrophTotal = enthrophTotal + (probab * Math.Log(1.0 / probab, 2));
                    
                    Console.WriteLine(keyValue.Key + "-- " + keyValue.Value +" ймовірність = " + probab + " ентропія = " + enthrophOne);
                    load = "";
                    kel++;
                    
                }
                hint = total * enthrophTotal;
                Console.WriteLine("==============================================================");
                Console.WriteLine("загальна ентропія " + enthrophTotal + " розмiр = " + hint);
            }
        }
    }
}
