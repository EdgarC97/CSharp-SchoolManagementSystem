using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    // Clase Student que hereda de Person
    public class Student : Person
    {
        // Propiedades específicas del estudiante
        public string? AttendantName { get; set; }
        public string? ActualCourse { get; set; }
        public DateOnly BornDate { get; set; }
        public List<double> Grades { get; private set; } = new List<double>();

        // Constructor que inicializa todas las propiedades
        public Student(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber, string attendantName, string actualCourse, DateOnly bornDate, List<double> grades) : base(name, lastName, documentType, documentNumber, emailAddress, phoneNumber)
        {
            AttendantName = attendantName;
            ActualCourse = actualCourse;
            BornDate = bornDate;
            Grades = grades;
        }
        // Métodos para establecer propiedades heredadas de Person
        public void SetName(string name) => Name = name;
        public void SetLastName(string lastName) => LastName = lastName;
        public void SetDocumentType(string documentType) => DocumentType = documentType;
        public void SetDocumentNumber(string documentNumber) => DocumentNumber = documentNumber;
        public void SetEmailAddress(string emailAddress) => EmailAddress = emailAddress;
        public void SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;

        //Methods
        // Muestra los detalles del estudiante en formato tabular
        public override void ShowDetails()
        {
            string gradesString = string.Join(", ", Grades.Select(g => g.ToString("0")));
            if (string.IsNullOrEmpty(gradesString))
            {
                gradesString = "Sin calificaciones";
            }
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{DocumentType,-12}|{DocumentNumber,-12}|{EmailAddress,-30}|{PhoneNumber,-12}|{AttendantName,-20}|{ActualCourse,-15}|{BornDate.ToString("yyyy-MM-dd"),-10}|{gradesString,-20}|");
        }
        // Agrega una calificación a la lista de calificaciones del estudiante
        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("La calificación debe estar entre 0 y 100.");
            Grades.Add(grade);
        }
        // Calcula el promedio de las calificaciones del estudiante
        private double CalculateAverageGrades()
        {
            double sum = Grades.Sum();
            double average = sum / Grades.Count;
            return average;
        }
        // Método público para obtener el promedio de calificaciones
        public double GetAverageGrades()
        {
            return CalculateAverageGrades();
        }
        // Calcula la edad del estudiante basándose en su fecha de nacimiento
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - BornDate.Year;
            if (DateTime.Today.Month < BornDate.Month || (DateTime.Today.Month == BornDate.Month && DateTime.Today.Day < BornDate.Day))
            {
                age--;
            }
            return age;
        }
        // Compara si este estudiante tiene el mismo nombre que otro
        public bool HasSameNameAs(Student other)
        {
            return this.GetName().Equals(other.GetName(), StringComparison.OrdinalIgnoreCase);
        }

        // Valida los datos del estudiante
        public override void Validate()
        {
            base.Validate(); // Llama a las validaciones de Person

            if (string.IsNullOrWhiteSpace(AttendantName))
                throw new ArgumentException("El nombre del acudiente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(ActualCourse))
                throw new ArgumentException("El curso actual no puede estar vacío.");

            if (Grades.Any(grade => grade < 0 || grade > 100))
                throw new ArgumentException("Las calificaciones deben estar entre 0 y 100.");
        }
        // Actualiza un campo específico del estudiante
        public void UpdateField(string fieldName, string newValue)
        {
            switch (fieldName)
            {
                case "Nombre":
                    Name = newValue;
                    break;
                case "Apellido":
                    LastName = newValue;
                    break;
                case "TipoDocumento":
                    DocumentType = newValue;
                    break;
                case "NumeroDocumento":
                    DocumentNumber = newValue;
                    break;
                case "CorreoElectronico":
                    EmailAddress = newValue;
                    break;
                case "NumeroTelefono":
                    PhoneNumber = newValue;
                    break;
                    // No es necesario incluir AttendantName, ActualCourse, BornDate o Grades aquí ya que se manejan directamente en el método EditStudentFromUserInput
            }
        }
    }
}