using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation
{
    public class ValidationResult : IValidationResult
    {
        public IList<IValidationError> Errors { get; private set; }

        public bool IsValid { get { return this.Errors.Count == 0; } }

        public ValidationResult()
        {
            this.Errors = new List<IValidationError>();
        }

        public void AddError(IValidationError error)
        {
            this.Errors.Add(error);
        }
    }
}
