using System;

namespace GildedRose.Inventory.Domain.Entities.Validation
{
    /// <summary>
    /// Represents a domain entity validation exception.
    /// </summary>
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
