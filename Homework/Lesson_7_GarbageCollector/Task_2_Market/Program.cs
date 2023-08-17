using System;

namespace Task_2_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tests for market");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Address _address = new Address("Lviv", "Naukova, 7b");
            using (var _yourClothes = new Market("Your Clothes", _address, MarketTypes.Clothing))
            {
                _yourClothes.Buy();
                _yourClothes.Sell();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
