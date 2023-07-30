using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_IntroClass_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            double testVar1 = 10.0;
            double testVar2 = 80.0;

            #region test of sum
            Console.WriteLine("Sum {0} + {1}: {2}", testVar1, testVar2, calculator.sum(testVar1, testVar2));
            Console.WriteLine();
            #endregion

            #region test of difference
            Console.WriteLine("Difference {0} - {1}: {2}", testVar1, testVar2, calculator.dif(testVar1, testVar2));
            Console.WriteLine();
            #endregion

            #region test of multiplication
            Console.WriteLine("Multiplication {0} * {1}: {2}", testVar1, testVar2, calculator.mul(testVar1, testVar2));
            Console.WriteLine();
            #endregion

            #region test of division
            Console.WriteLine("Division {0} / {1}: {2}", testVar1, testVar2, calculator.div(testVar1, testVar2));
            Console.WriteLine();
            #endregion

            #region test of percentage
            Console.WriteLine("Percentage {0}% from {1}: {2}", testVar1, testVar2, calculator.perc(testVar1, testVar2));
            Console.WriteLine();
            #endregion

            #region test of square root
            Console.WriteLine("Square root from {0}: {1}", testVar1, calculator.sqrt(testVar1));
            Console.WriteLine();
            #endregion

            Console.ReadLine();
        }
    }
}

