using System;
using System.IO;

namespace CSAssignment3
{
    class Class3
    {   /// <summary>
    /// Reads the content of a file. Throws an exception if path is invalid or file doesn't exist.
    /// </summary>
    /// <param name="filePath">Path of file where it is stored. </param>
        public static void ReadFile(string filePath)
        {
            try
            {

                string text = File.ReadAllText(filePath);
                Console.WriteLine(text);
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(Class3Constants.FileNotFoundMessage+ex.Message); // if entered file is not found
            }

            catch (ArgumentException)
            {
                Console.WriteLine(Class3Constants.ArgumentExceptionMessage); // if entered path is invalid
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(Class3Constants.DirectoryNotFoundMessage);       // if directory doesn't exist or not found
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(Class3Constants.UnauthorizedAccessMessage);       // if ented path is unauthorized 
            }
            catch (Exception)
            {
                Console.WriteLine(Class3Constants.ExceptionMessage);        // for invalid input or other exceptions
            }
        }
    }
}
