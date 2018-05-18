using System;
using System.IO;

namespace CSPractice
{
    public class CS2
    {
        public static void Main()
        {
            CS2 file = new CS2();

            if (file.IsFileExist("hello.txt", "E:"))
            {
                Console.WriteLine("File Exists\n");
            }
            else
            {
                Console.WriteLine("File Doesn't Exist\n");
            }
        }
        /// <summary>
        /// returns a boolean value if the file exists in the given folder or subfolder
        /// </summary>
        /// <param name="fileName">Name of file to be searched.</param>
        /// <param name="folderPath">Path of folder to search the file in.</param>
        /// <returns></returns>
        public bool IsFileExist(string fileName, string folderPath)
        {
            if (File.Exists(Path.Combine(folderPath,fileName)))
            {
                return true;
            }
            foreach (string subDir in Directory.GetDirectories(folderPath,"*",SearchOption.AllDirectories))
            {
               if(IsFileExist(fileName, subDir))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
