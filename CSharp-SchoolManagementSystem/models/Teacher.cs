using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    // Clase Teacher que hereda de Person
    public class Teacher : Person
    {
        // Propiedades específicas del profesor
        public string? Subject { get; set; }
        private double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public List<string> Courses = new List<string>();

        // Constructor que inicializa todas las propiedades
        public Teacher(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber, string subject, double salary, DateTime startDate, List<string> courses) : base(name, lastName, documentType, documentNumber, emailAddress, phoneNumber)
        {
            Subject = subject;
            Salary = salary;
            StartDate = startDate;
            Courses = courses;
        }

        //Methods

        // Muestra los detalles del profesor en formato tabular
        public override void ShowDetails()
        {
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{DocumentType,-12}|{DocumentNumber,-12}|{EmailAddress,-30}|{PhoneNumber,-12}|{Subject,-15}|{Salary,-15:C}|{StartDate.ToString("yyyy-MM-dd"),-12}|{string.Join(", ", Courses),-30}|");
        }
        // Calcula los años de antigüedad del profesor
        public int CalculateAntiquity()
        {
            int years = DateTime.Today.Year - StartDate.Year;
            if (DateTime.Today.Month < StartDate.Month || (DateTime.Today.Month == StartDate.Month && DateTime.Today.Day < StartDate.Day))
            {
                years--;
            }
            return years;
        }
        // Obtiene el salario del profesor
        public double GetSalary()
        {
            return Salary;
        }
        // Compara si este profesor tiene el mismo nombre que otro
        public bool HasSameNameAs(Teacher other)
        {
            return this.GetName().Equals(other.GetName(), StringComparison.OrdinalIgnoreCase);
        }
        // Lista de cursos permitidos
        private static readonly List<string> AllowedCourses = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua",
            "Biología",
            "Informática",
            "Educación Física"
        };
        // Agrega un curso a la lista de cursos del profesor
        public void AddCourse(string course)
        {
            if (!AllowedCourses.Contains(course))
            {
                throw new ArgumentException("Los cursos permitidos son: Matemáticas, Física, Química, Historia, Lengua, Biología, Informática, y Educación Física.");
            }
            Courses.Add(course);
        }
        // Actualiza un campo específico del profesor
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
                case "Salario":
                    if (double.TryParse(newValue, out double salary))
                        Salary = salary;
                    break;
            }
        }
    }
}