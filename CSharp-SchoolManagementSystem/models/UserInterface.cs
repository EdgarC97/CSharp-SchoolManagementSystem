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
            Console.WriteLine("9. Salir");
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
                        Student student = new Student("Nombre", "Apellido", "DNI", "12345678",
                                "correo@ejemplo.com", "123-456-7890", "Padre/Madre/Tutor", "Carrera",
                                new DateOnly(2000, 1, 1),new List<double> { 80, 85, 90 });
                        AdministratorApp.AddStudent(student);
                        break;
                    // case 2:
                    //     _library.RemoveBookFromUserInput(); 
                    //     break;
                    // case 3:
                    //     _library.SearchBooksByAuthorFromUserInput(); 
                    //     break;
                    // case 4:
                    //     _library.SearchBooksByGenreFromUserInput(); 
                    //     break;
                    // case 5:
                    //     _library.SearchBooksByYearRangeFromUserInput(); 
                    //     break;
                    // case 6:
                    //     _library.ShowAllBooksSortedByYear(); 
                    //     break;
                    // case 7:
                    //     _library.ApplyDiscountToBookFromUserInput(); 
                    //     break;
                    // case 8:
                    //     _library.CheckIfBookIsRecentFromUserInput(); 
                    //     break;
                    case 9:
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
}
