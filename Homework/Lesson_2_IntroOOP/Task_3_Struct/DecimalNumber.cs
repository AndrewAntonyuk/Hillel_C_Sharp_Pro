using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct DecimalNumber
{
    public int value;

    public DecimalNumber(int value)
    {
        this.value = value;
    }

    public string toBin() => Convert.ToString(value, 2);

    public string toOct() => Convert.ToString(value, 8);

    public string toHex() => Convert.ToString(value, 16);

    public override string ToString() => value.ToString();
}
