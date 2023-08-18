using System;

namespace Task_3_DisposeDestruct
{
    internal class Person
    {
        #region data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        #endregion

        #region constructors
        public Person(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        #endregion

        #region public functions
        public override string ToString() => $"[First name: {FirstName}; middle name: {LastName}; last name: {MiddleName}]";
        #endregion

        ~Person() => Console.WriteLine("Person was destroyed:\n" + this);
    }
}
