using System.IO;

namespace CSAssignment2
{
    class FileSearch
    {   /// <summary>
    /// Retruns true of if a file exists in a given folder or sub-folder
    /// otherwise returns false
    /// </summary>
    /// <param name="fileName">Name of file with (extension)</param>
    /// <param name="folderPath">Path of folder to search file in</param>
    /// <returns></returns>
        public static bool IsFileExists(string fileName, string folderPath)
        {
            string tempPath = folderPath + '\\' + fileName;
            string[] files = Directory.GetFiles(folderPath);    //Listing Down Files

            foreach (string file in files)
            {
                if (file == tempPath) //matching name of file for its existence.
                {
                    return true;    //when file is found exit the loop.
                }
            }
            string[] directories = Directory.GetDirectories(folderPath);    //Listing Down Directories
            foreach (string directory in directories)       //Looking for sub-folder until it finds it ,when it is found it breaks loop.
            {

                if (IsFileExists(fileName, directory))
                    return true;               //calling function again to check the files.
            }
            return false;       //return true or false
        }
    }
}
