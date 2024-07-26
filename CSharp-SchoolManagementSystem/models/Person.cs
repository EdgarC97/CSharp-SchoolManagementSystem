using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_SchoolManagementSystem.models
{
    public class Person
    {
        protected Guid Id;
        protected string? Name;
        protected string? LastName;
        protected string? DocumentType;
        protected string? DocumentNumber;
        protected string? EmailAddress;
        protected string? PhoneNumber;

        //Constructor
        public Person(string name, string lastName, string documentType, string documentNumber, string emailAddress, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
        protected string GetName()
        {
            return Name ?? string.Empty;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"ID: {Id}\nName: {Name}\nLast Name: {LastName}\nDocument Type: {DocumentType}\nDocument Number: {DocumentNumber}\nEmail Address: {EmailAddress}\nPhone Number: {PhoneNumber}");
        }

        public virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("El nombre no puede estar vacío");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("El apellido no puede estar vacío");

            if (string.IsNullOrWhiteSpace(DocumentType))
                throw new ArgumentException("El tipo de documento no puede estar vacío");

            if (string.IsNullOrWhiteSpace(DocumentNumber))
                throw new ArgumentException("El tipo de documento no puede estar vacío");

            if (!IsValidEmail(EmailAddress))
                throw new ArgumentException("El correo electronico no tienes formato valido ");

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new ArgumentException("El número de teléfono no puede estar vacío");

            if (!IsValidPhoneNumber(PhoneNumber))
                throw new ArgumentException("El número de teléfono no tiene un formato válido.");
        }

        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        public static bool IsValidPhoneNumber(string? phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) &&
                   System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

    }
}
