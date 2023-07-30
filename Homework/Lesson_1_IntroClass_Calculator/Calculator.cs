using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_IntroClass_Calculator
{
    public class Calculator
    {
        public dynamic sum(dynamic add1, dynamic add2)
        {
            return add1 + add2;
        }

        public dynamic dif(dynamic minuend, dynamic subtrahend)
        {
            return minuend - subtrahend;
        }

        public dynamic mul(dynamic multiplicand, dynamic multiplier)
        {
            return multiplicand * multiplier;
        }

        public dynamic div(dynamic dividend, dynamic divisor)
        {
            return dividend / divisor;
        }

        public dynamic perc(dynamic percentage, dynamic total)
        {
            return percentage / 100.0 * total;
        }

        public dynamic sqrt(dynamic val)
        {
            return Math.Sqrt(val);
        }
    }
}