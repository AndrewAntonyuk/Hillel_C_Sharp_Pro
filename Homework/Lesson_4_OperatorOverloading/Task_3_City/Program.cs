using System;

namespace Task_3_City
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region header
                City[] cities = new City[]{new City("Paris", "France", 5000000),
                                           new City("Boston", "USA", 4000000),
                                           new City("Paris", "France", 5000000)};

                Console.WriteLine("Cities for testing of work city:");
                for (int i = 0; i < cities.Length; i++)
                {
                    Console.WriteLine($"City {i + 1}: \n" + cities[i]);
                }
                Console.WriteLine("================================");
                Console.WriteLine();
                #endregion

                #region increment people
                var incrementPeople = 500000;
                Console.WriteLine("Testing of sum: ");
                Console.WriteLine($"City 1 + {incrementPeople}:");
                Console.WriteLine(cities[0] + incrementPeople);
                Console.WriteLine();
                #endregion

                #region decrement people
                var decrementPeople = 500000;
                Console.WriteLine("Testing of dif: ");
                Console.WriteLine($"City 2 - {decrementPeople}:");
                Console.WriteLine(cities[1] - decrementPeople);
                Console.WriteLine();
                #endregion

                #region equals
                Console.WriteLine("Tests of equals:");
                Console.WriteLine($"City 1.Equals(City 2):" + (cities[0].Equals(cities[1])));
                Console.WriteLine($"City 1.Equals(City 3):" + (cities[0].Equals(cities[2])));
                Console.WriteLine($"City 1 == City 2:" + (cities[0] == cities[1]));
                Console.WriteLine($"City 1 == City 3:" + (cities[0] == cities[2]));
                Console.WriteLine($"City 2 != City 3:" + (cities[1] != cities[2]));
                Console.WriteLine($"City 1 > City 2:" + (cities[0] > cities[1]));
                Console.WriteLine($"City 2 < City 3:" + (cities[1] < cities[2]));
                Console.WriteLine();
                #endregion

                #region test with failure
                decrementPeople = 8000000;
                Console.WriteLine("Test with failure:");
                Console.WriteLine($"City 2 - {decrementPeople}:");
                Console.WriteLine(cities[1] - decrementPeople);
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
