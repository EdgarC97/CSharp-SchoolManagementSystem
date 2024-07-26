using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models;
// Defino la clase UserInterface que maneja la interacción con el usuario
public class UserInterface
{

    // Método principal que ejecuta el menú de la aplicación
    public static void Run()
    {
        bool exit = false; // Bandera para controlar la salida del bucle
        while (!exit)
        {
            // Limpio la consola para una presentación más limpia del menú
            Console.Clear();
            // Muestro el menú de opciones al usuario
            Console.WriteLine("=== Sistema de Gestión de Escuela ===");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Agregar profesor");
            Console.WriteLine("3. Editar información de estudiante");
            Console.WriteLine("4. Editar información de profesor");
            Console.WriteLine("5. Eliminar estudiante");
            Console.WriteLine("6. Eliminar profesor");
            Console.WriteLine("7. Visualizar informacion de estudiantes");
            Console.WriteLine("8. Visualizar informacion de profesores");
            Console.WriteLine("9. Mostrar ejercicios LINQ");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            // Leo la opción ingresada por el usuario y valida que sea un número
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                Console.ReadKey();
                continue;
            }

            try
            {
                // Ejecuto la acción correspondiente según la opción seleccionada
                switch (choice)
                {
                    case 1:
                        AdministratorApp.AddStudentFromUserInput();
                        break;
                    case 2:
                        AdministratorApp.AddTeacherFromUserInput();
                        break;
                    case 3:
                        AdministratorApp.EditStudentFromUserInput();
                        break;
                    case 4:
                        AdministratorApp.EditTeacherFromUserInput();
                        break;
                    case 5:
                        AdministratorApp.DeleteStudentFromUserInput();
                        break;
                    case 6:
                        AdministratorApp.DeleteTeacherFromUserInput();
                        break;
                    case 7:
                        AdministratorApp.ShowStudents();
                        break;
                    case 8:
                        AdministratorApp.ShowTeachers();
                        break;
                    case 9:
                        ShowReports();
                        break;
                    case 10:
                        exit = true; // Establezco la bandera exit a true para salir del bucle
                        Console.WriteLine("Gracias por usar el Sistema de Gestión de Escuela. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo."); // Mensaje para opciones no válidas
                        break;
                }
            }
            catch (Exception ex)
            {
                // Capturo y muestra cualquier excepción que ocurra durante la ejecución
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (!exit)
            {
                // Solicito al usuario que presione una tecla para continuar si no se ha salido
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private static void ShowReports()
    {
        Console.Clear();
        Console.WriteLine("=== Consultas y Reportes ===");
        Console.WriteLine("1. Estudiantes con promedio de calificaciones superior a 85");
        Console.WriteLine("2. Profesores que enseñan más de un curso");
        Console.WriteLine("3. Estudiantes mayores de 16 años");
        Console.WriteLine("4. Estudiantes ordenados por apellido");
        Console.WriteLine("5. Salario total de todos los profesores");
        Console.WriteLine("6. Estudiante con la calificación más alta");
        Console.WriteLine("7. Número de estudiantes por curso");
        Console.WriteLine("8. Profesores con más de 10 años de antigüedad");
        Console.WriteLine("9. Asignaturas únicas impartidas en la escuela");
        Console.WriteLine("10. Estudiantes con nombre de acudiente 'María'");
        Console.WriteLine("11. Profesores ordenados por salario descendente");
        Console.WriteLine("12. Promedio de edad de los estudiantes");
        Console.WriteLine("13. Profesores que enseñan 'Matemáticas'");
        Console.WriteLine("14. Estudiantes con más de tres calificaciones");
        Console.WriteLine("15. Antigüedad promedio de los profesores");
        Console.WriteLine("0. Volver al menú principal");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out int reportChoice))
        {
            Console.WriteLine("Por favor, ingrese un número válido.");
            Console.ReadKey();
            return;
        }

        switch (reportChoice)
        {
            case 1:
                Console.Clear();
                var highAchievers = AdministratorApp.GetHighAchievers(AdministratorApp.students);
                Console.WriteLine("Estudiantes con promedio de calificaciones superior a 85:");
                foreach (var student in highAchievers)
                {
                    student.ShowDetails();
                }
                break;
            case 2:
                Console.Clear();
                var teachersWithMultipleCourses = AdministratorApp.GetTeachersWithMultipleCourses(AdministratorApp.teachers);
                Console.WriteLine("Profesores que enseñan más de un curso:");
                foreach (var teacher in teachersWithMultipleCourses)
                {
                    teacher.ShowDetails();
                }
                break;
            case 3:
                Console.Clear();
                var studentsOlderThan16 = AdministratorApp.GetStudentsOlderThan16(AdministratorApp.students);
                Console.WriteLine("Estudiantes mayores de 16 años:");
                foreach (var student in studentsOlderThan16)
                {
                    student.ShowDetails();
                }
                break;
            case 4:
                Console.Clear();
                var studentsOrderedByLastName = AdministratorApp.GetStudentsOrderedByLastName(AdministratorApp.students);
                Console.WriteLine("Estudiantes ordenados por apellido:");
                foreach (var student in studentsOrderedByLastName)
                {
                    student.ShowDetails();
                }
                break;
            case 5:
                Console.Clear();
                var totalSalaries = AdministratorApp.CalculateTotalSalary(AdministratorApp.teachers);
                Console.WriteLine($"Salario total de todos los profesores: {totalSalaries:C}");
                break;
            case 6:
                Console.Clear();
                var topStudent = AdministratorApp.GetStudentWithHighestGrade(AdministratorApp.students);
                Console.WriteLine("Estudiante con la calificación más alta:");
                topStudent?.ShowDetails();
                break;
            case 7:
                Console.Clear();
                AdministratorApp.CountStudentsByCourse();
                break;
            case 8:
                Console.Clear();
                var experiencedTeachers = AdministratorApp.GetTeachersWithMoreThan10YearsOfExperience(AdministratorApp.teachers);
                Console.WriteLine("Profesores con más de 10 años de antigüedad:");
                foreach (var teacher in experiencedTeachers)
                {
                    teacher.ShowDetails();
                }
                break;
            case 9:
                Console.Clear();
                var uniqueSubjects = AdministratorApp.GetUniqueSubjects(AdministratorApp.teachers);
                Console.WriteLine("Asignaturas únicas impartidas en la escuela:");
                foreach (var subject in uniqueSubjects)
                {
                    Console.WriteLine(subject);
                }
                break;
            case 10:
                Console.Clear();
                var studentsWithAttendantMaria = AdministratorApp.GetStudentsWithAttendantNameMaria(AdministratorApp.students);
                Console.WriteLine("Estudiantes con nombre de acudiente 'María':");
                foreach (var student in studentsWithAttendantMaria)
                {
                    student.ShowDetails();
                }
                break;
            case 11:
                Console.Clear();
                var teachersOrderedBySalaryDesc = AdministratorApp.GetTeachersOrderedBySalaryDesc(AdministratorApp.teachers);
                Console.WriteLine("Profesores ordenados por salario descendente:");
                foreach (var teacher in teachersOrderedBySalaryDesc)
                {
                    teacher.ShowDetails();
                }
                break;
            case 12:
                Console.Clear();
                var averageAge = AdministratorApp.CalculateAverageAge(AdministratorApp.students);
                Console.WriteLine($"Promedio de edad de los estudiantes: {averageAge:F2} años");
                break;
            case 13:
                Console.Clear();
                var teachersForMathematics = AdministratorApp.GetTeachersForMathematics(AdministratorApp.teachers);
                Console.WriteLine("Profesores que enseñan 'Matemáticas':");
                foreach (var teacher in teachersForMathematics)
                {
                    teacher.ShowDetails();
                }
                break;
            case 14:
                Console.Clear();
                var studentsWithMoreThanThreeGrades = AdministratorApp.GetStudentsWithMoreThanThreeGrades(AdministratorApp.students);
                Console.WriteLine("Estudiantes con más de tres calificaciones:");
                foreach (var student in studentsWithMoreThanThreeGrades)
                {
                    student.ShowDetails();
                }
                break;
            case 15:
                Console.Clear();
                var averageAntiquity = AdministratorApp.CalculateAverageAntiquity(AdministratorApp.teachers);
                Console.WriteLine($"Antigüedad promedio de los profesores: {averageAntiquity:F2} años");
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                break;
        }
    }
}