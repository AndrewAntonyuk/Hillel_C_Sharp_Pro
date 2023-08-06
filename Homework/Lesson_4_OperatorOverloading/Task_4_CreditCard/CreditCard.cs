using System;
using System.Collections.Generic;

namespace Task_4_CreditCard
{
    public class CreditCard
    {
        #region internal data
        private string _cvc;
        private string _number;
        private decimal _total;
        #endregion

        #region properties
        public string Cvc { get => _cvc; }
        public string Number { get => _number; }
        public decimal Total
        {
            get => _total;
            set
            {
                CheckTotal(value);
                _total = value;
            }
        }
        #endregion

        #region constructors
        public CreditCard(string cvc, string number) : this(cvc, number, 0)
        {
        }

        public CreditCard(string cvc, string number, decimal total)
        {
            _cvc = cvc;
            _number = number;
            Total = total;
        }

        public CreditCard(CreditCard creditCard)
        {
            this._cvc = creditCard.Cvc;
            this._number = creditCard.Number;
            this.Total = creditCard.Total;
        }
        #endregion

        #region public methods
        public static CreditCard operator +(CreditCard creditCard, decimal increaseValue)
        {
            var retCreditCard = new CreditCard(creditCard);

            retCreditCard.Total += increaseValue;

            return retCreditCard;
        }

        public static CreditCard operator -(CreditCard creditCard, decimal decreaseValue)
        {
            var retCreditCard = new CreditCard(creditCard);

            retCreditCard.Total -= decreaseValue;

            return retCreditCard;
        }

        public static bool operator ==(CreditCard creditCard1, CreditCard creditCard2)
        {
            return creditCard1.Cvc.Equals(creditCard2.Cvc);
        }

        public static bool operator !=(CreditCard creditCard1, CreditCard creditCard2)
        {
            return !creditCard1.Cvc.Equals(creditCard2.Cvc);
        }

        public static bool operator >(CreditCard creditCard1, CreditCard creditCard2)
        {
            return creditCard1.Total > creditCard2.Total;
        }

        public static bool operator <(CreditCard creditCard1, CreditCard creditCard2)
        {
            return creditCard1.Total < creditCard2.Total;
        }

        public override string ToString()
        {
            return $"Number: {Number}; CVC: {Cvc}; total: {Total}";
        }

        public override bool Equals(object obj)
        {
            return obj is CreditCard card &&
                   Cvc == card.Cvc &&
                   Number == card.Number &&
                   Total == card.Total;
        }

        public override int GetHashCode()
        {
            int hashCode = -1846706059;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_cvc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_number);
            hashCode = hashCode * -1521134295 + _total.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cvc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            hashCode = hashCode * -1521134295 + Total.GetHashCode();
            return hashCode;
        }
        #endregion

        #region internal methods
        private void CheckTotal(decimal total)
        {
            if (total < 0)
            {
                throw new ArgumentException("Total can't be less than zero");
            }
        }
        #endregion
    }
}
