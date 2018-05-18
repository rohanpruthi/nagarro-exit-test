using System;
using System.Collections.Generic;
using System.Linq;

namespace listeg
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> num = new List<int> { 11, 12, 13, 14, 15 };
            for (int i = 0; i < num.Count(); i++)
            {
                Console.WriteLine("{0}\n", num[i]);
            }
        }
    }
}
