using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Money
{
    public class Money
    {
        #region data
        private int _wholePart;
        private int _fractionalPart;
        private string _currency;
        #endregion

        #region properties
        public int WholePart { get => _wholePart; }
        public int FractionalPart { get => _fractionalPart; }
        public string Currency { get => _currency; set => _currency = value; }
        #endregion

        #region constructors
        public Money() : this("Undef currency")
        {
        }

        public Money(string currency) : this(0, 0, currency)
        {
        }

        public Money(int wholePart, int fractionalPart, string currency)
        {
            _wholePart = wholePart;
            _fractionalPart = fractionalPart;
            _currency = currency;
        }
        #endregion

        #region public metods      
        public override string ToString() => $"Currency: {_currency}; cost: {_wholePart}.{_fractionalPart:00}.";

        public void setCost(int whole, int fractional)
        {
            checkPart(fractional, 100);
            checkPart(whole, -1);

            _wholePart = whole;
            _fractionalPart = fractional;
        }
        #endregion

        #region internal metods
        private void checkPart(int partValue, int maxValue)
        {
            if (partValue < 0)
            {
                throw new ArgumentOutOfRangeException($"The value {partValue} is illegal because it's less than zero");
            }

            if ((partValue >= maxValue) && !(maxValue <= 0))
            {
                throw new ArgumentOutOfRangeException($"The value {partValue} is illegal because it exceeds max range: {maxValue}");
            }
        }
        #endregion
    }
}
