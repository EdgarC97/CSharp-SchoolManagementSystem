using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public static class AdministratorApp
    {
        // Datos iniciales para pruebas y desarrollo
        // Lista de estudiantes inicial
        public static List<Student> students = new List<Student>
    {
        new Student(
            "Juan", "Pérez", "DNI", "12345678",
            "juan.perez@email.com", "3007448967",
            "John Doe", "Informatica", new DateOnly(1997, 1, 1),
             new List<double> {29, 88, 95, 87, 91 }
        ),
        new Student(
            "Ana", "García", "Pasaporte", "AB123456",
            "ana.garcia@email.com", "3007448969",
            "María García", "Matemáticas", new DateOnly(2015, 5, 15),
            new List<double> { 25 }
        ),
        new Student(
            "Carlos", "López", "DNI", "87654321",
            "carlos.lopez@email.com", "3007489613",
            "Pedro López", "Química", new DateOnly(2001, 8, 22),
            new List<double> { 76, 82, 89, 91, 85 }
        ),
        new Student(
            "Laura", "Martínez", "DNI", "23456789",
            "laura.martinez@email.com", "3007448960",
            "Elena Martínez", "Química", new DateOnly(2000, 11, 30),
            new List<double> { 88, 94, 79, 86, 92 }
        ),
        new Student(
            "Miguel", "Fernández", "Pasaporte", "CD987654",
            "miguel.fernandez@email.com", "3007448963",
            "María", "Biología", new DateOnly(2001, 3, 10),
            new List<double> { 90, 87, 93, 81, 100 }
        )
    };
        // Lista de profesores inicial
        public static List<Teacher> teachers = new List<Teacher>
    {
        new Teacher(
            "Juan", "Pérez", "DNI", "98765432",
            "juan.perez@email.com", "3017448967",
            "Física", 4500000, new DateTime(1991, 5, 15),
            new List<string> {  "Matematicas","Física","Quimica" }
        ),
        new Teacher(
            "María", "González", "DNI", "87654321",
            "maria.gonzalez@email.com", "3027448967",
            "Historia", 3800000, new DateTime(1970, 9, 10),
            new List<string> { "Historia","Lengua","Biologia" }
        ),
        new Teacher(
            "Carlos", "López", "DNI", "76543210",
            "carlos.lopez@email.com", "3037448967",
            "Inglés", 4200000, new DateTime(1963, 3, 20),
            new List<string> { "Informatica" }
        ),
        new Teacher(
            "Carlos", "López", "DNI", "76543210",
            "carlos.lopez@email.com", "3037448967",
            "Matemáticas", 4200000, new DateTime(1997, 3, 20),
            new List<string> { "Matemáticas,Educación Física" }
        )
    };
        //CRUD ESTUDIANTE

        // Agrega un nuevo estudiante a la lista, validando duplicados
        public static void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            student.Validate();

            if (students.Any(s => s.HasSameNameAs(student)))
                throw new ArgumentException($"Ya existe un estudiante con el nombre {student}.", nameof(student));

            students.Add(student);
        }
        // Interfaz de usuario para agregar un nuevo estudiante
        public static void AddStudentFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar estudiante ===");

            try
            {
                Student newStudent = new Student(
                    GetValidInput("Nombre"),
                    GetValidInput("Apellido"),
                    GetValidInput("Tipo de documento"),
                    GetValidInput("Número de documento"),
                    GetValidEmailInput(),
                    GetValidPhoneNumberInput(),
                    GetValidInput("Nombre del acudiente"),
                    GetValidInput("Curso actual"),
                    GetValidDateInput("Fecha de nacimiento"),
                    new List<double>()
                );

                GetStudentGrades(newStudent);

                AddStudent(newStudent);
                Console.WriteLine("Estudiante agregado correctamente.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al agregar estudiante: {ex.Message}");
            }
        }
        // Interfaz de usuario para editar un estudiante existente
        public static void EditStudentFromUserInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=== Lista de Estudiantes ===\n");
                Console.WriteLine($"{"Nro",-5}|{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Acudiente",-20}|{"Curso",-15}|{"Fecha Nac.",-10}|{"Calificaciones",-20}|");
                Console.WriteLine(new string('-', 178));

                for (int i = 0; i < students.Count; i++)
                {
                    Console.Write($"{i + 1,-5}|");
                    students[i].ShowDetails();
                }

                Console.Write("\nIngrese el número del estudiante que desea editar o '0' para volver al menú principal: ");
                if (!int.TryParse(Console.ReadLine(), out int studentNumber) || studentNumber < 0 || studentNumber > students.Count)
                {
                    Console.WriteLine("Número inválido.");
                    return;
                }

                if (studentNumber == 0)
                    return;

                Student studentToEdit = students[studentNumber - 1];

                bool continueEditing = true;
                while (continueEditing)
                {
                    Console.WriteLine("\nCampos disponibles para editar:");
                    Console.WriteLine("1. Nombre");
                    Console.WriteLine("2. Apellido");
                    Console.WriteLine("3. Tipo de documento");
                    Console.WriteLine("4. Número de documento");
                    Console.WriteLine("5. Correo electrónico");
                    Console.WriteLine("6. Número de teléfono");
                    Console.WriteLine("7. Nombre del acudiente");
                    Console.WriteLine("8. Curso actual");
                    Console.WriteLine("9. Fecha de nacimiento");
                    Console.WriteLine("10. Calificaciones");

                    Console.Write("\nIngrese el número del campo que desea editar: ");
                    if (!int.TryParse(Console.ReadLine(), out int fieldChoice) || fieldChoice < 1 || fieldChoice > 10)
                    {
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        continue;
                    }

                    switch (fieldChoice)
                    {
                        case 1:
                            UpdateStudentField(studentToEdit, "Nombre", GetValidInput("Nuevo nombre"));
                            break;
                        case 2:
                            UpdateStudentField(studentToEdit, "Apellido", GetValidInput("Nuevo apellido"));
                            break;
                        case 3:
                            UpdateStudentField(studentToEdit, "TipoDocumento", GetValidInput("Nuevo tipo de documento"));
                            break;
                        case 4:
                            UpdateStudentField(studentToEdit, "NumeroDocumento", GetValidInput("Nuevo número de documento"));
                            break;
                        case 5:
                            UpdateStudentField(studentToEdit, "CorreoElectronico", GetValidEmailInput());
                            break;
                        case 6:
                            UpdateStudentField(studentToEdit, "NumeroTelefono", GetValidPhoneNumberInput());
                            break;
                        case 7:
                            studentToEdit.AttendantName = GetValidInput("Nuevo nombre del acudiente");
                            break;
                        case 8:
                            studentToEdit.ActualCourse = GetValidInput("Nuevo curso actual");
                            break;
                        case 9:
                            studentToEdit.BornDate = GetValidDateInput("Nueva fecha de nacimiento");
                            break;
                        case 10:
                            EditStudentGrades(studentToEdit);
                            break;
                    }

                    Console.Write("\n¿Desea editar otro campo? (s/n): ");
                    continueEditing = Console.ReadLine().TrimSafely().ToLower() == "s";
                }

                Console.WriteLine("\nLos datos se han editado con éxito.");
                Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
                return;
            }
        }
        // Permite al usuario editar las calificaciones de un estudiante
        private static void EditStudentGrades(Student student)
        {
            Console.WriteLine($"Calificaciones actuales: {string.Join(", ", student.Grades)}");
            Console.WriteLine("Ingrese las nuevas calificaciones (separadas por comas):");
            string input = Console.ReadLine().TrimSafely();
            List<double> newGrades = new List<double>();

            foreach (string gradeStr in input.Split(','))
            {
                if (double.TryParse(gradeStr.Trim(), out double grade))
                {
                    try
                    {
                        student.AddGrade(grade);
                        newGrades.Add(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine($"Calificación inválida: {gradeStr}. Se omitirá.");
                }
            }

            student.Grades.Clear();
            student.Grades.AddRange(newGrades);
            Console.WriteLine($"Nuevas calificaciones: {string.Join(", ", student.Grades)}");
        }
        // Actualiza un campo específico de un estudiante
        private static void UpdateStudentField(Student student, string fieldName, string newValue)
        {
            student.UpdateField(fieldName, newValue);
        }
        // Muestra la lista de estudiantes en formato tabular
        public static void ShowStudents()
        {
            Console.WriteLine("\n=== Lista de Estudiantes ===\n");
            Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Acudiente",-20}|{"Curso",-15}|{"Fecha Nac.",-10}|{"Calificaciones",-20}|");
            Console.WriteLine(new string('-', 161));

            foreach (var student in students)
            {
                student.ShowDetails();
            }
            Console.WriteLine(new string('-', 161));
        }
        // Interfaz de usuario para eliminar un estudiante
        public static void DeleteStudentFromUserInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=== Lista de Estudiantes ===\n");
                Console.WriteLine($"{"Nro",-5}|{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Acudiente",-20}|{"Curso",-15}|{"Fecha Nac.",-10}|{"Calificaciones",-20}|");
                Console.WriteLine(new string('-', 167));

                for (int i = 0; i < students.Count; i++)
                {
                    Console.Write($"{i + 1,-5}|");
                    students[i].ShowDetails();
                }

                Console.Write("\nIngrese el número del estudiante que desea eliminar o '0' para volver al menú principal: ");
                if (!int.TryParse(Console.ReadLine(), out int studentNumber) || studentNumber < 0 || studentNumber > students.Count)
                {
                    Console.WriteLine("Número inválido.");

                    return;
                }

                if (studentNumber == 0)
                    return;

                Console.Write($"¿Está seguro de eliminar el estudiante #{studentNumber}? ('s' confirma, cualquier tecla cancela): ");
                if (Console.ReadLine().TrimSafely().ToLower() == "s")
                {
                    students.RemoveAt(studentNumber - 1);
                    Console.WriteLine("Estudiante eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Usted ha cancelado la eliminación.");
                }
                return;
            }
        }

        //CRUD PROFESOR
        // Agrega un nuevo profesor a la lista, validando duplicados
        public static void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            teacher.Validate();

            if (teachers.Any(s => s.HasSameNameAs(teacher)))
                throw new ArgumentException($"Ya existe un profesor con el nombre {teacher}.", nameof(teacher));

            teachers.Add(teacher);
        }
        // Interfaz de usuario para agregar un nuevo profesor
        public static void AddTeacherFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar profesor ===");

            try
            {
                Teacher newTeacher = new Teacher(
                    GetValidInput("Nombre"),
                    GetValidInput("Apellido"),
                    GetValidInput("Tipo de documento"),
                    GetValidInput("Número de documento"),
                    GetValidEmailInput(),
                    GetValidPhoneNumberInput(),
                    GetValidInput("Materia"),
                    GetValidSalaryInput(),
                    GetValidDateTimeInput("Fecha de inicio"),
                    new List<string>()

                );
                GetTeacherCourses(newTeacher);

                AddTeacher(newTeacher);
                Console.WriteLine("Profesor agregado correctamente.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al agregar profesor: {ex.Message}");
            }
        }
        // Interfaz de usuario para editar un profesor existente
        public static void EditTeacherFromUserInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=== Lista de Profesores ===\n");
                Console.WriteLine($"{"Nro",-5}|{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Materia",-15}|{"Salario",-15}|{"Fecha Inicio",-12}|{"Cursos",-30}|");
                Console.WriteLine(new string('-', 174));

                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.Write($"{i + 1,-5}|");
                    teachers[i].ShowDetails();
                }

                Console.Write("\nIngrese el número del profesor que desea editar o '0' para volver al menú principal: ");
                if (!int.TryParse(Console.ReadLine(), out int teacherNumber) || teacherNumber < 0 || teacherNumber > teachers.Count)
                {
                    Console.WriteLine("Número inválido.");
                    return;
                }

                if (teacherNumber == 0)
                    return;

                Teacher teacherToEdit = teachers[teacherNumber - 1];

                bool continueEditing = true;
                while (continueEditing)
                {
                    Console.WriteLine("\nCampos disponibles para editar:");
                    Console.WriteLine("1. Nombre");
                    Console.WriteLine("2. Apellido");
                    Console.WriteLine("3. Tipo de documento");
                    Console.WriteLine("4. Número de documento");
                    Console.WriteLine("5. Correo electrónico");
                    Console.WriteLine("6. Número de teléfono");
                    Console.WriteLine("7. Materia");
                    Console.WriteLine("8. Salario");
                    Console.WriteLine("9. Fecha de inicio");
                    Console.WriteLine("10. Cursos");

                    Console.Write("\nIngrese el número del campo que desea editar: ");
                    if (!int.TryParse(Console.ReadLine(), out int fieldChoice) || fieldChoice < 1 || fieldChoice > 10)
                    {
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        continue;
                    }

                    switch (fieldChoice)
                    {
                        case 1:
                            UpdateTeacherField(teacherToEdit, "Nombre", GetValidInput("Nuevo nombre"));
                            break;
                        case 2:
                            UpdateTeacherField(teacherToEdit, "Apellido", GetValidInput("Nuevo apellido"));
                            break;
                        case 3:
                            UpdateTeacherField(teacherToEdit, "TipoDocumento", GetValidInput("Nuevo tipo de documento"));
                            break;
                        case 4:
                            UpdateTeacherField(teacherToEdit, "NumeroDocumento", GetValidInput("Nuevo número de documento"));
                            break;
                        case 5:
                            UpdateTeacherField(teacherToEdit, "CorreoElectronico", GetValidEmailInput());
                            break;
                        case 6:
                            UpdateTeacherField(teacherToEdit, "NumeroTelefono", GetValidPhoneNumberInput());
                            break;
                        case 7:
                            teacherToEdit.Subject = GetValidInput("Nueva asignación");
                            break;
                        case 8:
                            UpdateTeacherField(teacherToEdit, "Salario", GetValidSalaryInput().ToString());
                            break;
                        case 9:
                            teacherToEdit.StartDate = GetValidDateTimeInput("Nueva fecha de inicio");
                            break;
                        case 10:
                            EditTeacherCourses(teacherToEdit);
                            break;
                    }

                    Console.Write("\n¿Desea editar otro campo? (s/n): ");
                    continueEditing = Console.ReadLine().TrimSafely().ToLower() == "s";
                }

                Console.WriteLine("\nLos datos se han editado con éxito.");
                Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
                return;
            }
        }
        // Permite al usuario editar los cursos de un profesor
        private static void EditTeacherCourses(Teacher teacher)
        {
            Console.WriteLine($"Cursos actuales: {string.Join(", ", teacher.Courses)}");
            Console.WriteLine("Ingrese los nuevos cursos (separados por comas):");
            string input = Console.ReadLine().TrimSafely();
            List<string> newCourses = new List<string>();

            foreach (string courseInput in input.Split(','))
            {
                try
                {
                    teacher.AddCourse(courseInput);
                    newCourses.Add(courseInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            teacher.Courses.Clear();
            teacher.Courses.AddRange(newCourses);
            Console.WriteLine($"Nuevos cursos: {string.Join(", ", teacher.Courses)}");
        }
        // Actualiza un campo específico de un profesor
        private static void UpdateTeacherField(Teacher teacher, string fieldName, string newValue)
        {
            teacher.UpdateField(fieldName, newValue);
        }
        // Interfaz de usuario para eliminar un profesor
        public static void DeleteTeacherFromUserInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=== Lista de Profesores ===\n");
                Console.WriteLine($"{"Nro",-5}|{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Materia",-15}|{"Salario",-15}|{"Fecha Inicio",-12}|{"Cursos",-30}|");
                Console.WriteLine(new string('-', 174));

                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.Write($"{i + 1,-5}|");
                    teachers[i].ShowDetails();
                }

                Console.Write("\nIngrese el número del profesor que desea eliminar o '0' para volver al menú principal: ");
                if (!int.TryParse(Console.ReadLine(), out int teacherNumber) || teacherNumber < 0 || teacherNumber > teachers.Count)
                {
                    Console.WriteLine("Número inválido.");
                    return;
                }

                if (teacherNumber == 0)
                    return;

                Console.Write($"¿Está seguro de eliminar el profesor #{teacherNumber}? ('s' confirma, cualquier tecla cancela): ");
                if (Console.ReadLine().TrimSafely().ToLower() == "s")
                {
                    teachers.RemoveAt(teacherNumber - 1);
                    Console.WriteLine("Profesor eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Usted ha cancelado la eliminación.");
                }
                return;
            }
        }
        // Muestra la lista de profesores en formato tabular
        public static void ShowTeachers()
        {
            Console.WriteLine("\n=== Lista de Profesores ===\n");
            Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Email",-30}|{"Teléfono",-12}|{"Materia",-15}|{"Salario",-15}|{"Fecha Inicio",-12}|{"Cursos",-30}|");
            Console.WriteLine(new string('-', 168));

            foreach (var teacher in teachers)
            {
                teacher.ShowDetails();
            }
            Console.WriteLine(new string('-', 168));
        }

        //VALIDACIONES
        // Métodos de validación para diferentes tipos de entrada de usuario
        // Estos métodos aseguran que los datos ingresados sean válidos y consistentes

        // Solicita y valida la entrada del usuario para un campo específico
        private static string GetValidInput(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName}: ");
                string input = Console.ReadLine().TrimSafely();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine($"El {fieldName.ToLower()} no puede estar vacío.");
            }
        }
        // Solicita y valida un correo electrónico
        private static string GetValidEmailInput()
        {
            while (true)
            {
                string input = GetValidInput("Correo electrónico");
                if (Person.IsValidEmail(input))
                    return input;
                Console.WriteLine("El correo electrónico no es válido.");
            }
        }
        // Solicita y valida un número de teléfono
        private static string GetValidPhoneNumberInput()
        {
            while (true)
            {
                string input = GetValidInput("Número de teléfono");
                if (Person.IsValidPhoneNumber(input))
                    return input;
                Console.WriteLine("El número de teléfono no es válido (debe contener 10 dígitos).");
            }
        }
        // Solicita y valida una fecha en formato YYYY-MM-DD
        private static DateOnly GetValidDateInput(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName} (YYYY-MM-DD): ");
                string input = Console.ReadLine().TrimSafely();
                if (DateOnly.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateOnly date))
                {
                    return date;
                }
                Console.WriteLine("Fecha no válida. Use el formato YYYY-MM-DD.");
            }
        }
        // Solicita y valida un salario (número positivo)
        private static double GetValidSalaryInput()
        {
            while (true)
            {
                Console.Write("Salario: ");
                if (double.TryParse(Console.ReadLine(), out double salary) && salary > 0)
                {
                    return salary;
                }
                Console.WriteLine("Por favor, ingrese un salario válido (número positivo).");
            }
        }
        // Solicita y valida una fecha y hora en formato YYYY-MM-DD
        private static DateTime GetValidDateTimeInput(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName} (YYYY-MM-DD): ");
                string input = Console.ReadLine().TrimSafely();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                Console.WriteLine("Fecha no válida. Use el formato YYYY-MM-DD.");
            }
        }
        // Solicita y valida las calificaciones de un estudiante
        private static void GetStudentGrades(Student student)
        {
            Console.WriteLine("Ingrese las calificaciones del estudiante del 0 al 100 O Deje en blanco para finalizar.");
            while (true)
            {
                Console.Write("Calificación: ");
                string input = Console.ReadLine().TrimSafely();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (double.TryParse(input, out double grade))
                {
                    try
                    {
                        student.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }
        }
        // Solicita y valida los cursos de un profesor
        private static void GetTeacherCourses(Teacher teacher)
        {
            Console.WriteLine("Ingrese los cursos del profesor (deje en blanco para finalizar):");
            while (true)
            {
                Console.Write("Curso: ");
                string input = Console.ReadLine().TrimSafely();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                try
                {
                    teacher.AddCourse(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //METODOS LINQ
        // Estos métodos utilizan LINQ para realizar consultas y operaciones sobre las colecciones de estudiantes y profesores

        // 1. Estudiantes con promedio de calificaciones superior a 85
        public static List<Student> GetHighAchievers(List<Student> students)
        {
            return students
            .Where(s => s.GetAverageGrades() > 85)
            .ToList();
        }
        // 2. Profesores que enseñan más de un curso
        public static List<Teacher> GetTeachersWithMultipleCourses(List<Teacher> teachers)
        {
            return teachers.Where(t => t.Courses.Count > 1).ToList();
        }
        // 3. Estudiantes mayores de 16 años
        public static List<Student> GetStudentsOlderThan16(List<Student> students)
        {
            return students.Where(s => s.CalculateAge() > 16).ToList();
        }
        // 4. Estudiantes ordenados por apellido
        public static List<Student> GetStudentsOrderedByLastName(List<Student> students)
        {
            return students.OrderBy(s => s.GetLastName()).ToList();
        }
        // 5. Salario total de todos los profesores
        public static double CalculateTotalSalary(List<Teacher> teachers)
        {
            double totalSalary = 0;
            foreach (var teacher in teachers)
            {
                totalSalary += teacher.GetSalary();
            }
            return totalSalary;
        }
        // 6. Estudiante con la calificación más alta en su curso actual
        public static Student? GetStudentWithHighestGrade(List<Student> students)
        {
            return students.OrderByDescending(s => s.Grades.Max()).FirstOrDefault();
        }
        // 7. Número de estudiantes por curso
        public static void CountStudentsByCourse()
        {
            // Filtrar los estudiantes con ActualCourse no nulo
            var studentsWithValidCourses = students
                .Where(s => s.ActualCourse != null)
                .ToList();

            // Crear el diccionario de conteo de estudiantes por curso
            var studentCountsByCourse = studentsWithValidCourses
                .GroupBy(s => s.ActualCourse!)
                .ToDictionary(g => g.Key, g => g.Count());

            // Mostrar los resultados
            foreach (var course in studentCountsByCourse)
            {
                Console.WriteLine($"Curso: {course.Key} - Número de estudiantes: {course.Value}");
            }
        }
        // 8. Profesores con más de 10 años de antigüedad
        public static List<Teacher> GetTeachersWithMoreThan10YearsOfExperience(List<Teacher> teachers)
        {
            return teachers.Where(t => t.CalculateAntiquity() > 10).ToList();
        }
        // 9. Asignaturas únicas impartidas en la escuela
        public static List<string> GetUniqueSubjects(List<Teacher> teachers)
        {
            return teachers.SelectMany(t => t.Courses).Distinct().ToList();
        }
        // 10. Estudiantes con nombre de acudiente 'María'
        public static List<Student> GetStudentsWithAttendantNameMaria(List<Student> students)
        {
            return students.Where(s => s.AttendantName?.Equals("María", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
        // 11. Profesores ordenados por salario descendente
        public static List<Teacher> GetTeachersOrderedBySalaryDesc(List<Teacher> teachers)
        {
            return teachers.OrderByDescending(t => t.GetSalary()).ToList();
        }
        // 12. Promedio de edad de los estudiantes
        public static double CalculateAverageAge(List<Student> students)
        {
            return students.Average(s => s.CalculateAge());
        }
        // 13. Profesores que enseñan 'Matemáticas'
        public static List<Teacher> GetTeachersForMathematics(List<Teacher> teachers)
        {
            return teachers.Where(t => t.Subject?.Equals("Matemáticas", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
        // 14. Estudiantes con más de tres calificaciones
        public static List<Student> GetStudentsWithMoreThanThreeGrades(List<Student> students)
        {
            return students.Where(s => s.Grades.Count > 3).ToList();
        }
        // 15. Antigüedad promedio de los profesores
        public static double CalculateAverageAntiquity(List<Teacher> teachers)
        {
            return teachers.Average(t => t.CalculateAntiquity());
        }
    };
}
