using System;

namespace Task_3_DisposeDestruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Tests for market");
                Console.WriteLine("=====================");
                Console.WriteLine();

                Address _address = new Address(null, "Naukova, 7b");
                using (var _yourClothes = new Market("Your Clothes", _address, MarketTypes.Clothing))
                {
                    _yourClothes.Buy();
                    _yourClothes.Sell();
                    Console.WriteLine();
                }

                Test();

                Console.WriteLine();
                Console.WriteLine("Test of destructor:");

                GC.Collect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message);
            }

            Console.ReadLine();
        }

        private static void Test()
        {
            #region header
            Console.WriteLine("Tests for play");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Person _authorOHT = new Person("Ivan", "Karpovych", "Tobilevych");
            Play _oneHundredThousands = new Play("The One hundred Tausends",
                                                PlayTypes.Tragicomedy,
                                                1889,
                                                _authorOHT);
            #endregion

            #region test of functions
            _oneHundredThousands.Run();
            _oneHundredThousands.Pause();
            #endregion
        }
    }
}
