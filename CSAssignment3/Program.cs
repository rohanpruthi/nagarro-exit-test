using System;
using System.Collections.Generic;

namespace CSAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.SwitchCaseMessage + Constants.EndLine);
            int switchCase = Convert.ToInt32(Console.ReadLine());
            switch (switchCase)
            {
                case 1:
                    {
                        Console.WriteLine(Class1Constants.InputMessage + Constants.EndLine);
                        Class1 obj = new Class1();
                        int number = obj.ReadNumber();
                        obj.SqaureRoot(number);
                    }
                    break;
                case 2:
                    {
                        int n = Class2Constants.size;
                        int start = Class2Constants.begin;
                        int end = Class2Constants.end;
                        List<int> list = new List<int>();
                        for (int i = default; i < n; i++)
                        {
                            int temp = Class2.ReadNumber(start, end);
                            if (temp > start)
                            {
                                list.Add(temp);
                            }
                            else
                            {
                                --i;
                            }
                        }
                        Class2.DisplayList(list);
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine(Class3Constants.FilePathMessage+Constants.EndLine);
                        string filePath = Console.ReadLine();
                        Class3.ReadFile(filePath);
                    }
                    break;
                default:
                    {
                        Console.WriteLine(Constants.InvalidInputMessage);
                    }
                    break;
                    Console.ReadKey();
            }

        }
    }
}

