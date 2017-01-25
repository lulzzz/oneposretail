using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePos.Framework.Validation
{
    public class ValidationResult
    {
        private readonly IList<ValidationError> _errors = new List<ValidationError>();

        public bool IsValid
        {
            get { return ! Errors.Any(); }
        }

        public IEnumerable<ValidationError> Errors { get { return _errors; } }

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public void AddError( string message, string key )
        {
            _errors.Add(new ValidationError() { Message = message, Key = key } );
        }

        public void MergeResults(ValidationResult result)
        {
            foreach (var error in result.Errors)
                AddError( error );
        }

        public void EnsureIsValid()
        {
            if (!IsValid) throw new ValidationException(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var error in Errors)
            {
                if (string.IsNullOrEmpty(error.Key))
                    sb.Append(error.Message + Environment.NewLine);
                else
                    sb.Append( string.Format( "{0} - {1}{2}", error.Key, error.Message, Environment.NewLine ) );
            }
            return sb.ToString();
        }
    }
}
