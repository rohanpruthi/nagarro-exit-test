using System;

namespace CSAssignment3
{
    public class Class1
    {
        /// <summary>
        /// Reads an integer from user and returns.
        /// </summary>
        /// <returns>number entered by user</returns>
        public int ReadNumber()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }
        /// <summary>
        /// Calculates square root of an integer and returns the solution. Returns a respective message if
        /// an exception exists.
        /// </summary>
        /// <param name="number">Number to calculate the square root of.</param>
        public void SqaureRoot(int number)
        {
            try
            {
                if (number < default(int))
                {
                    throw new ArithmeticException();        // throwing exception for -ve no;
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArithmeticException)
            {
                Console.WriteLine(Class1Constants.ExceptionMessage + Constants.EndLine);
            }
            catch (Exception)                               //if other exception occurs
            {
                Console.WriteLine(Class1Constants.ExceptionMessage + Constants.EndLine);
            }
            finally                                         //Always executes whether exception is thrown or not
            {
                Console.WriteLine(Class1Constants.FinallyMessage + Constants.EndLine);
            }

        }
    }
}
