using System;

namespace CompanyStructure.Exceptions
{
    public class NonPositiveWageException : Exception
    {
        public NonPositiveWageException() { }
        public NonPositiveWageException(string message) : base(message) { }
        public NonPositiveWageException(string message, Exception inner) : base(message, inner) { }
    }
}
