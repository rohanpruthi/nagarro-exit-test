using System;
using System.Collections.Generic;

namespace CSAssignment3
{
    class Class2
    {
        /// <summary>
        /// Enters a number and check if the number files between
        /// a given range start and end. Or throws an exception
        /// if invalid input is given.
        /// </summary>
        /// <param name="start">begin of range including itself</param>
        /// <param name="end">end of range including itself</param>
        /// <returns>number in case its valid or a number unit less than start</returns>
        public static int ReadNumber(int start, int end)
        {
            int test = 0;
            Console.WriteLine("Enter the number in  range: {0} to {1} ", start, end);
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (num >= start && num <= end)
                {
                    test = num;
                    return num;
                }
                throw new ArithmeticException();
            }

            catch (FormatException)
            {
                Console.WriteLine(Class2Constants.FormatExceptionMessage + Constants.EndLine);     //if input is not integer
                return start - 1;
            }

            catch (ArithmeticException)
            {
                Console.WriteLine(Class2Constants.ArithmeticExceptionMessage + Constants.EndLine);      //if input is not in given range
                return start - 1;
            }
        }
        /// <summary>
        /// Display list of integer entered by user
        /// </summary>
        /// <param name="list"></param>
        public static void DisplayList(List<int> list)
        {
            for (int i = default; i < list.Count; i++)
                Console.WriteLine("{0 }", list[i]);
        }
    }
}
