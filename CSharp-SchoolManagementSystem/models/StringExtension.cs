using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public static class StringExtensions
    {   
        // Método de extensión estático que se puede usar en cualquier instancia de la clase string que realiza un recorte seguro de espacios en blanco.
        public static string TrimSafely(this string? input)
        {
            // Usa el operador null-coalescing para devolver el resultado de Trim si input no es null, o una cadena vacía si input es null
            return input?.Trim() ?? string.Empty;
        }
    }
}