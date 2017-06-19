using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Contracts.Validation
{
    public interface IValidationEngine<T>
    {
        IList<IValidationRule<T>> ValidationRules { get; }
        Dictionary<string, IList<IValidationRule<T>>> ValidationGroups { get; }
        void AddRule(IValidationRule<T> rule);
        void AddRule(string group, IValidationRule<T> rule);
        IValidationResult Validate(T obj);
        IValidationResult Validate(IEnumerable<T> objList);
    }
}
