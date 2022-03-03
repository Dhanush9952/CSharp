using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLastSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int First = numbers.FirstOrDefault();
            System.Console.WriteLine("First or Default: {0}",First);
            int First1 = numbers.FirstOrDefault(num => num > 10);
            Console.WriteLine(First1);
            int Last = numbers.LastOrDefault();
            System.Console.WriteLine("Last or Default:");
            Console.WriteLine(Last);
            int Single = numbers.SingleOrDefault(num => num > 10);
            System.Console.WriteLine("Single or Default:");
            Console.WriteLine(Single); // output '0' (Default)
        }
    }
}
