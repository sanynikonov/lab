using System;

namespace CompanyStructure.Exceptions
{
    public class EmptyCompanyException : Exception
    {
        public EmptyCompanyException() { }
        public EmptyCompanyException(string message) : base(message) { }
        public EmptyCompanyException(string message, Exception inner) : base(message, inner) { }
    }
}
