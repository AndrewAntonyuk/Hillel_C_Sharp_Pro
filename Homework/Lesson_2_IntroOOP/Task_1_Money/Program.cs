using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Banana", 1000, new Money(99, 99, "$"));

            try
            {
                Console.WriteLine("Product before decrease price: \n" + product);

                product.decreaseCost(1000);

                Console.WriteLine("Product after decrease price: \n" + product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
