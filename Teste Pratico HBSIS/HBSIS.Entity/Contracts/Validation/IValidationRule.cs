using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Contracts.Validation
{
    public interface IValidationRule<T>
    {
        bool IsSatisfiedBy(T obj);
        IValidationError GetError();
    }
}
