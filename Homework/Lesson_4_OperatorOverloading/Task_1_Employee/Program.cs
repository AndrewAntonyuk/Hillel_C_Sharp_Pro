using System;

namespace Task_1_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region header and prepare test object
                Employee employee1 = new Employee
                {
                    FirstName = "John",
                    LastName = "Galt",
                    Age = 35,
                    Position = "Manager",
                    Salary = 25000.0
                };

                Employee employee2 = new Employee
                {
                    FirstName = "John",
                    LastName = "Galt",
                    Age = 35,
                    Position = "Manager",
                    Salary = 25000.0
                };

                Employee employee3 = new Employee
                {
                    FirstName = "Rocky",
                    LastName = "Balboa",
                    Age = 29,
                    Position = "Sequrity",
                    Salary = 55000.0
                };

                Console.WriteLine("Base employees:" + "\n 1: " + employee1 + "\n 2: " + employee2 + "\n 3: " + employee3);
                Console.WriteLine("================================");
                #endregion

                #region increment salary
                var incrementSalary = 1000.0;
                Console.WriteLine($"Employee 1 after increment salary at {incrementSalary:.00}:" + "\n" + (employee1 += incrementSalary));
                Console.WriteLine();
                #endregion

                #region decrement salary
                var decrementSalary = 1000.0;
                Console.WriteLine($"Employee 1 after decrement salary at {decrementSalary:.00}:" + "\n" + (employee1 -= decrementSalary));
                Console.WriteLine();
                #endregion

                #region equals
                Console.WriteLine("Equals tests:");
                Console.WriteLine($"Employee 1.Equals(employee 2):" + (employee1.Equals(employee2)));
                Console.WriteLine($"Employee 2.Equals(employee 3):" + (employee2.Equals(employee3)));
                Console.WriteLine($"Employee 1 == employee 2:" + (employee1 == employee2));
                Console.WriteLine($"Employee 1 == employee 3:" + (employee1 == employee3));
                Console.WriteLine($"Employee 2 != employee 3:" + (employee2 != employee3));
                Console.WriteLine($"Employee 1  < employee 3:" + (employee1 < employee3));
                Console.WriteLine($"Employee 3  > employee 2:" + (employee3 > employee2));
                Console.WriteLine();
                #endregion

                #region test with failure
                Console.WriteLine("Test with failure:");
                decrementSalary = 30000.0;
                Console.WriteLine($"Employee 1 after decrement salary at {decrementSalary:.00}:" + "\n" + (employee1 -= decrementSalary));
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
