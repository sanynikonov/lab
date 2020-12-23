using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyStructure.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException() { }
        public InvalidNameException(string message) : base(message) { }
        public InvalidNameException(string message, Exception inner) : base(message, inner) { }
    }
}
