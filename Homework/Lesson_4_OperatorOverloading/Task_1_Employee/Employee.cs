using System;
using System.Collections.Generic;

namespace Task_1_Employee
{
    public class Employee
    {
        #region internal data
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _position;
        private double _salary;
        #endregion

        #region constructors
        public Employee() : this("UndefFirstName") { }

        public Employee(string firstName) : this(firstName, "UndefLastName") { }

        public Employee(string firstName, string lastName) : this(firstName, lastName, 18) { }

        public Employee(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Employee(Employee employee)
        {
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Age = employee.Age;
            this.Position = employee.Position;
            this.Salary = employee.Salary;
        }
        #endregion

        #region properties
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Age
        {
            get => _age;
            set
            {
                CheckNumbers(value);
                _age = value;
            }
        }
        public string Position { get => _position; set => _position = value; }
        public double Salary
        {
            get => _salary;
            set
            {
                CheckNumbers(value);
                _salary = value;
            }
        }
        #endregion

        #region public methods
        public static Employee operator +(Employee employee, double inrementSalary)
        {
            Employee newEmployee = new Employee(employee);
            newEmployee.Salary = employee.Salary + inrementSalary;

            return newEmployee;
        }

        public static Employee operator -(Employee employee, double decrementSalary)
        {
            Employee newEmployee = new Employee(employee);
            newEmployee.Salary = employee.Salary - decrementSalary;

            return newEmployee;
        }

        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return employee1.Salary == employee2.Salary;
        }

        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return employee1.Salary != employee2.Salary;
        }

        public static bool operator >(Employee employee1, Employee employee2)
        {
            return employee1.Salary > employee2.Salary;
        }

        public static bool operator <(Employee employee1, Employee employee2)
        {
            return employee1.Salary < employee2.Salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee employee)
            {
                return FirstName.Equals(employee.FirstName)
                    && LastName.Equals(employee.LastName)
                    && Age == employee.Age
                    && Position.Equals(employee.Position)
                    && (Salary - employee.Salary) < 0.001;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Firstname: {FirstName}; Lastname: {LastName}; Age: {Age}; Position: {Position}; Salary: {Salary:.00}";
        }

        public override int GetHashCode()
        {
            int hashCode = -426231889;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + _age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_position);
            hashCode = hashCode * -1521134295 + _salary.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Position);
            hashCode = hashCode * -1521134295 + Salary.GetHashCode();
            return hashCode;
        }
        #endregion

        #region internal methods
        private void CheckNumbers(dynamic value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(nameof(value) + $" {value} can't be less or equal zero");
            }
        }
        #endregion
    }
}
