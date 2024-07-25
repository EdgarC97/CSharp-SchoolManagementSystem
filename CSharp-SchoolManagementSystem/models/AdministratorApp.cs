using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public static class AdministratorApp
    {
        public static List<Student> students = new List<Student>
    {
        new Student(
            "Juan", "Pérez", "DNI", "12345678",
            "juan.perez@email.com", "123-456-7890",
            "John Doe", "Informatica", new DateOnly(1997, 1, 1),
             new List<double> { 85, 90, 78, 92, 88 }
        ),
        new Student(
            "Ana", "García", "Pasaporte", "AB123456",
            "ana.garcia@email.com", "987-654-3210",
            "María García", "Matemáticas", new DateOnly(2000, 5, 15),
            new List<double> { 92, 88, 95, 87, 91 }
        ),
        new Student(
            "Carlos", "López", "DNI", "87654321",
            "carlos.lopez@email.com", "456-789-0123",
            "Pedro López", "Física", new DateOnly(2001, 8, 22),
            new List<double> { 76, 82, 89, 91, 85 }
        ),
        new Student(
            "Laura", "Martínez", "DNI", "23456789",
            "laura.martinez@email.com", "789-012-3456",
            "Elena Martínez", "Química", new DateOnly(2000, 11, 30),
            new List<double> { 88, 94, 79, 86, 92 }
        ),
        new Student(
            "Miguel", "Fernández", "Pasaporte", "CD987654",
            "miguel.fernandez@email.com", "012-345-6789",
            "Roberto Fernández", "Biología", new DateOnly(2001, 3, 10),
            new List<double> { 90, 87, 93, 81, 89 }
        )
    };
        public static List<Teacher> teachers = new List<Teacher>
    {
        new Teacher(
            "Juan", "Pérez", "DNI", "98765432",
            "juan.perez@email.com", "987-654-3210",
            "Física", 4500.00, new DateTime(2012, 5, 15),
            new List<string> {  "Matematicas","Física","Quimica" }
        ),
        new Teacher(
            "María", "González", "DNI", "87654321",
            "maria.gonzalez@email.com", "876-543-2109",
            "Historia", 3800.00, new DateTime(2008, 9, 10),
            new List<string> { "Historia","Lengua","Biologia" }
        ),
        new Teacher(
            "Carlos", "López", "DNI", "76543210",
            "carlos.lopez@email.com", "765-432-1098",
            "Inglés", 4200.00, new DateTime(2015, 3, 20),
            new List<string> { "Informatica", "Educacion fisica" }
        )
    };
        //Methods
        public static void AddStudent(Student student)
        {
            Console.WriteLine("Ingrese los datos del estudiante:");
            students.Add(student);
            Console.WriteLine("Estudiante agregado correctamente.");
        }
        public static void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }
        public static void ShowStudents()
        {
            foreach (var student in students)
            {
                student.ShowDetails();
                Console.WriteLine($"Student Name: {student.AttendantName}\nActual Course: {student.ActualCourse}\nBorn Date: {student.BornDate}\n");
            }

        }
        public static void ShowTeachers()
        {
            foreach (var teacher in teachers)
            {
                teacher.ShowDetails();
                Console.WriteLine($"Teacher Assignment: {teacher.Assignment}\nStart Date: {teacher.StartDate}\n");
            }
        }

    };
}
