using System;

namespace Task_2_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();

                GC.Collect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message);
            }

            Console.ReadLine();
        }

        static void Test()
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

            using (var _yourNewClothes = new Market("Your New Clothes", null, MarketTypes.Clothing))
            {
                _yourNewClothes.Buy();
                _yourNewClothes.Sell();
                Console.WriteLine();
            }
        }
    }
}
