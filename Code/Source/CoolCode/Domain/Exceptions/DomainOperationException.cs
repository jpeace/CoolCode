using System;

namespace CoolCode.Domain.Exceptions
{
    public class DomainOperationException : Exception
    {
        public DomainOperationException(string message) : base(message) {}
    }
}