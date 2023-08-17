using System;

namespace Task_3_DisposeDestruct
{
    internal class Market : IDisposable
    {
        #region data
        private bool _disposed;
        public string Name { get; set; }
        public Address Address { get; set; }
        public MarketTypes MarketType { get; set; }
        #endregion

        #region constructors
        public Market(string name, Address address, MarketTypes marketType)
        {
            Name = name;
            Address = address;
            MarketType = marketType;
        }
        #endregion

        #region public functions
        public override string ToString()
        {
            return $"[Market name: {Name}; market type: {MarketType.ToString()}; address: {Address}]";
        }

        public void Buy()
        {
            Console.WriteLine($"Buying in progress for market:\n {this}");
        }

        public void Sell()
        {
            Console.WriteLine($"Selling in progress for market:\n {this}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Console.WriteLine($"Dispose controlled recourses of {this}");
            }

            Console.WriteLine($"Dispose uncontrolled recourses of {this}");

            _disposed = true;
        }

        ~Market()
        {
            Dispose(false);
        }
    }
}
