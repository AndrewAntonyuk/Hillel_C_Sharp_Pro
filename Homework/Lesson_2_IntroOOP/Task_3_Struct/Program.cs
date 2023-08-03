using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DecimalNumber number = new DecimalNumber(-1);

                Console.WriteLine($"Result of convertions for {number}:");
                Console.WriteLine($"In binary form: {number.toBin()}");
                Console.WriteLine($"In octal form: {number.toOct()}");
                Console.WriteLine($"In hexadecimal form: {number.toHex()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
