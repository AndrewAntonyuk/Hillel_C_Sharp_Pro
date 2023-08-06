using System;

namespace Task_4_CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region header
                CreditCard[] cards = new CreditCard[]{new CreditCard("432","1111-2222-3333-4444-5555", new decimal(250.00)),
                                                      new CreditCard("754","5555-4444-3333-2222-1111", new decimal(760.05)),
                                                      new CreditCard("432","1111-2222-3333-4444-5555", new decimal(250.00))};

                Console.WriteLine("Cards for testing of work with cards:");
                for (int i = 0; i < cards.Length; i++)
                {
                    Console.WriteLine($"Card {i + 1}: \n" + cards[i]);
                }
                Console.WriteLine("================================");
                Console.WriteLine();
                #endregion

                #region increment total
                var incrementTotal = new decimal(550.05);
                Console.WriteLine("Testing of increase: ");
                Console.WriteLine($"Card 1 + {incrementTotal}:");
                Console.WriteLine(cards[0] + incrementTotal);
                Console.WriteLine();
                #endregion

                #region decrement total
                var decrementTotal = new decimal(100.10);
                Console.WriteLine("Testing of decrease: ");
                Console.WriteLine($"Card 2 - {decrementTotal}:");
                Console.WriteLine(cards[1] - decrementTotal);
                Console.WriteLine();
                #endregion

                #region equals
                Console.WriteLine("Tests of equals:");
                Console.WriteLine($"Card 1.Equals(Card 2):" + (cards[0].Equals(cards[1])));
                Console.WriteLine($"Card 1.Equals(Card 3):" + (cards[0].Equals(cards[2])));
                Console.WriteLine($"Card 1 == Card 2:" + (cards[0] == cards[1]));
                Console.WriteLine($"Card 1 == Card 3:" + (cards[0] == cards[2]));
                Console.WriteLine($"Card 2 != Card 3:" + (cards[1] != cards[2]));
                Console.WriteLine($"Card 1 > Card 2:" + (cards[0] > cards[1]));
                Console.WriteLine($"Card 2 < Card 3:" + (cards[1] < cards[2]));
                Console.WriteLine();
                #endregion

                #region test with failure
                decrementTotal = new decimal(10000.10);
                Console.WriteLine("Test with failure:");
                Console.WriteLine($"Card 2 - {decrementTotal}:");
                Console.WriteLine(cards[1] - decrementTotal);
                Console.WriteLine();
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
