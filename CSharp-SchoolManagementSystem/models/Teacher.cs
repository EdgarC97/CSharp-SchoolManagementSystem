using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public class Teacher : Person
    {
        public string? Assignment { get; set; }
        private double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public List<string> Courses = new List<string>();

        //Constructor
        public Teacher(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber,string assignment, double salary, DateTime startDate, List<string>courses) : base(name, lastName, documentType, documentNumber, emailAddress, phoneNumber)
        {
            Assignment = assignment;
            Salary = salary;
            StartDate = startDate;
            Courses = courses;
        }

        //Methods
        public int CalculateAntiquity()
        {
            int years = DateTime.Today.Year - StartDate.Year;
            if (DateTime.Today.Month < StartDate.Month || (DateTime.Today.Month == StartDate.Month && DateTime.Today.Day < StartDate.Day))
            {
                years--;
            }
            return years;
        }
        public void GetSalary()
        {
            var salary = Salary;
            Console.WriteLine($"The teacher's salary is: {salary:C}");
        }
    }
}