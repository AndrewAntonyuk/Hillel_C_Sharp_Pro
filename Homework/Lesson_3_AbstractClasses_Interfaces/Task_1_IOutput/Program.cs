using System;

namespace Task_1_IOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOutput outputNormal = new Array(new int[] { 1, 65, 98, -87, 875 });
            IOutput outputNull = new Array(null);

            try
            {
                //Test of normal case
                outputNormal.Show();

                Console.WriteLine();

                outputNormal.Show("Output array:");

                //Test with null array
                //outputNull.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
