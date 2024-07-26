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
        public List<double> Grades { get; private set; } = new List<double>();

        //Constructor
        public Student(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber, string attendantName, string actualCourse, DateOnly bornDate, List<double> grades) : base(name, lastName, documentType, documentNumber, emailAddress, phoneNumber)
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
        public void AddGrade(double grade)
        {
            if (grade < 1 || grade > 5)
                throw new ArgumentException("La calificación debe estar entre 1 y 5.");
            Grades.Add(grade);
        }
        private void CalculateAverageGrades()
        {
            double sum = Grades.Sum();
            double average = sum / Grades.Count;
            Console.WriteLine($"The average grade is: {average}");
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
        public bool HasSameNameAs(Student other)
        {
            return this.GetName().Equals(other.GetName(), StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{GetName()} {LastName}";
        }
        public override void Validate()
        {
            base.Validate(); // Llama a las validaciones de Person

            if (string.IsNullOrWhiteSpace(AttendantName))
                throw new ArgumentException("El nombre del acudiente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(ActualCourse))
                throw new ArgumentException("El curso actual no puede estar vacío.");

            if (Grades.Any(grade => grade < 1 || grade > 5))
                throw new ArgumentException("Las calificaciones deben estar entre 1 y 5.");
        }
    }
}