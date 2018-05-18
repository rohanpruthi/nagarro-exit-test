using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAssignment2
{
    public class ConstantString             //common constants or const used in Program class
    {
        public const string EndLine = "\n";
        public const string InsertSpace = " ";
        public const string EnterChoice = "Enter Ques no. 1, 2, 3 or 4";
        public const string ChoiceErrorMessage = "Wrong Input";
        public const string CRLF = "\r\n";

    }
    public class Class1Constants            //consts used in class1.cs
    {
        public const string EnterFileName = "Enter the name of file with extention that you want to search e.g: date.cs";
        public const string EnterFolderName = "Enter the path where the file is to be searched e.g C:/Users/Documents";
        public static string FileFound(bool foo)
        {
            if (foo)
            {
                return "Yippe! File Found";
            }
            return "Sorry! File Not Found";
        }
        public const string ExceptionMessage = "Wrong Path Specified or folder not found ! Please try again";
    }
    public class Class2Constants            //consts used in class.cs
    {
        public const string EnterSize = "Enter The Size";
        public const string EnterValue = "Enter The Value";
        public const string EnterValueChoice = "Do you want to Enter More Values?(Y/N)";
    }
    public class Class3Constants            //consts used in class3.cs
    {
        public const string LevelOrder = "Level Order Traversal is:";
        public const string SprialOrder = "Spiral Order Traversal is:";
    }
}
