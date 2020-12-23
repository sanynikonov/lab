using System;

namespace CompanyStructure.Exceptions
{
    public class InvalidEmployeeException : Exception
    {
        public InvalidEmployeeException() { }
        public InvalidEmployeeException(string message) : base(message) { }
        public InvalidEmployeeException(string message, Exception inner) : base(message, inner) { }
    }
}
