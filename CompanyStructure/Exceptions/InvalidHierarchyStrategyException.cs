using System;

namespace CompanyStructure.Exceptions
{
    public class InvalidHierarchyStrategyException : Exception
    {
        public InvalidHierarchyStrategyException() { }
        public InvalidHierarchyStrategyException(string message) : base(message) { }
        public InvalidHierarchyStrategyException(string message, Exception inner) : base(message, inner) { }
    }
}
