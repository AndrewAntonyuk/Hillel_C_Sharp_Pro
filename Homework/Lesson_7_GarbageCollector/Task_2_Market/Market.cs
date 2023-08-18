using System;

namespace Task_2_Market
{
    internal class Market : IDisposable
    {
        #region data
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
        public override string ToString() => $"[Market name: {Name}; market type: {MarketType}; address: {Address?.ToString()}]";

        public void Buy() => Console.WriteLine($"Buying in progress for market:\n {this}");

        public void Sell() => Console.WriteLine($"Selling in progress for market:\n {this}");

        public void Dispose() => Console.WriteLine($"Market {this} has been disposed\n");
        #endregion
    }
}
