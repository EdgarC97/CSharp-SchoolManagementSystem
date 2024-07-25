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

        public virtual void ShowDetails()
        {
            Console.WriteLine($"ID: {Id}\nName: {Name}\nLast Name: {LastName}\nDocument Type: {DocumentType}\nDocument Number: {DocumentNumber}\nEmail Address: {EmailAddress}\nPhone Number: {PhoneNumber}");
        }


    }
}
