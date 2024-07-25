using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public class Student : Person
    {
        public string? AttendantName { get; set; }
        public string? ActualCourse { get; set; }
        public DateOnly BornDate { get; set; }
        public List<double> Grades = new List<double>();

        //Constructor
        public Student(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber, string attendantName, string actualCourse, DateOnly bornDate,List<double> grades) :base (name, lastName, documentType, documentNumber, emailAddress, phoneNumber)
        {
            AttendantName = attendantName;
            ActualCourse = actualCourse;
            BornDate = bornDate;
            Grades = grades;
        }

        //Methods
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Attendant Name: {AttendantName}\nActual Course: {ActualCourse}\nBorn Date: {BornDate}\n");
        }
        public void AddQualification(double qualification)
        {
            Grades.Add(qualification);
        }
        private void CalculateAverageQualification()
        {
            double sum = Grades.Sum();
            double average = sum / Grades.Count;
            Console.WriteLine($"The average qualification is: {average}");
        }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - BornDate.Year;
            if (DateTime.Today.Month < BornDate.Month || (DateTime.Today.Month == BornDate.Month && DateTime.Today.Day < BornDate.Day))
            {
                age--;
            }
            return age;
        }
    }
}