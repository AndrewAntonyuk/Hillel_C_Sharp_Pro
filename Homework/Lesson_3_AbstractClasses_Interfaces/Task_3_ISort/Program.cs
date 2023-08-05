using System;

namespace Task_3_ISort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 1, 65, 98, -87, 875 };

            ISort sortNormal = new Array(testArray);
            ISort sortNull = new Array(null);

            try
            {
                //Test of normal case
                #region header
                Console.WriteLine("Array for tests:");
                Console.WriteLine("[{0}]", string.Join(", ", testArray));
                Console.WriteLine("================================");
                #endregion

                #region Asc order sorting
                Console.WriteLine("Test for ascending order:");
                Console.WriteLine("Array after sorting: ");

                sortNormal.SortAsc();

                Console.WriteLine("[{0}]", string.Join(", ", testArray));
                Console.WriteLine();
                #endregion

                #region Desc order sorting
                Console.WriteLine("Test for descending order:");
                Console.WriteLine("Array after sorting: ");

                sortNormal.SortDesc();

                Console.WriteLine("[{0}]", string.Join(", ", testArray));
                Console.WriteLine();
                #endregion

                #region By parameter order sorting
                Console.WriteLine("Test for parameter order:");

                Console.WriteLine("Array after sorting with ascending parameter: ");
                sortNormal.SortByParam(true);
                Console.WriteLine("[{0}]", string.Join(", ", testArray));

                Console.WriteLine("Array after sorting with descending parameter: ");
                sortNormal.SortByParam(false);
                Console.WriteLine("[{0}]", string.Join(", ", testArray));

                Console.WriteLine();
                #endregion

                //Test with null array
                //sortNull.SortAsc();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
