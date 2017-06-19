using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Contracts.Validation
{
    public interface IValidationError
    {
        string Message { get; }
        string PropertyName { get; }
    }
}
