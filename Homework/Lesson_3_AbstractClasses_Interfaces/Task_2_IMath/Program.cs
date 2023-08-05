using System;

namespace Task_2_IMath
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 1, 65, 98, -87, 875 };

            IMath mathNormal = new Array(testArray);
            IMath mathNull = new Array(null);

            try
            {
                //Test of normal case
                #region header
                Console.WriteLine("Array for tests:");
                foreach (int i in testArray)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                Console.WriteLine("================================");
                #endregion

                #region maximum value
                Console.WriteLine("Test for Max value:");
                Console.WriteLine("The maximum value: " + mathNormal.Max());
                Console.WriteLine();
                #endregion

                #region minimum value
                Console.WriteLine("Test for Min value:");
                Console.WriteLine("The minimum value: " + mathNormal.Min());
                Console.WriteLine();
                #endregion

                #region average value
                Console.WriteLine("Test for Avg value:");
                Console.WriteLine("The average value: " + mathNormal.Avg());
                Console.WriteLine();
                #endregion

                #region search in array set value
                Console.WriteLine("Test for searching value:");
                Console.WriteLine("Array has 65: " + mathNormal.Search(65));
                Console.WriteLine("Array has 777: " + mathNormal.Search(777));
                Console.WriteLine();
                #endregion

                //Test with null array
                //mathNull.Max();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
