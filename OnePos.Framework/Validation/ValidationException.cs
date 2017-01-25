using System;

namespace OnePos.Framework.Validation
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult result)
            : base("Error validating object: " + result)
        {
            Result = result;
        }

        public ValidationResult Result { get; private set; }
    }
}
