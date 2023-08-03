using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Money
{
    internal class Product
    {
        #region data
        private Money _price;
        private string _name;
        private int _quantity;
        #endregion

        #region properties
        public string Name { get => _name; set => _name = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        #endregion

        #region constructors
        public Product() : this("Undefined product")
        {
        }

        public Product(string name) : this(name, 0)
        {
        }

        public Product(string name, int quantity) : this(name, quantity, new Money())
        {
        }

        public Product(string name, int quantity, Money price)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
        }
        #endregion

        #region public metods
        public override string ToString() => $"Product: {_name}; quantity: {_quantity}; price: (" + _price.ToString() + ")";

        public void decreaseCost(int coins)
        {
            checkPrice(coins);

            int sumPrice = _price.WholePart * 100 + _price.FractionalPart;

            _price.setCost((sumPrice - coins) / 100, (sumPrice - coins) % 100);
        }
        #endregion

        #region internal metods
        private void checkPrice(int decreaseAmount)
        {
            if (decreaseAmount > (_price.WholePart * 100 + _price.FractionalPart))
            {
                throw new ArgumentException($"Can't decrease {decreaseAmount} because it exceeds price {_price.ToString()}");
            }
        }
        #endregion
    }
}
