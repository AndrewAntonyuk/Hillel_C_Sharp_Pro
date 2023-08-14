namespace Lesson6.SOLID.V2
{
    //Принцип відкритості/закритості(Open/Closed Principle) можна сформулювати так:
    // Сутність програми повинна бути відкрита для розширення, але закрита для зміни.

    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public bool Add(Employee emp)
        {
            return true;
        }
    }

    // incorrect implementation
    public class EmployeeReport
    {
        public string TypeReport { get; set; }

        public void GenerateReport(Employee em)
        {
            if (TypeReport == "CSV")
            {
                // Генерация отчета в формате CSV
            }

            if (TypeReport == "PDF")
            {
                // Генерация отчета в формате PDF
            }
        }
    }

    //
    public interface IEmployeeReport
    {
        void GenerateReport(Employee em);
    }

    public class EmployeeCsvReport : IEmployeeReport
    {
        public void GenerateReport(Employee em)
        {
            // 
        }
    }

    public class EmployeePdfReport : IEmployeeReport
    {
        public void GenerateReport(Employee em)
        {
            // 
        }
    }

    public static class OpenClosedPrincipleDemo
    {
        public static void Demo()
        {
            
        }
    }
}

