using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public static class StringExtensions
    {
        public static string TrimSafely(this string? input)
        {
            return input?.Trim() ?? string.Empty;
        }
    }
}