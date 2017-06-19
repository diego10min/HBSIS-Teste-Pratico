using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation
{
    public abstract class ValidationEngine<T> : IValidationEngine<T>
    {

        public IList<IValidationRule<T>> ValidationRules { get; private set; }
        public Dictionary<string, IList<IValidationRule<T>>> ValidationGroups { get; private set; }

        public ValidationEngine()
        {
            this.ValidationRules = new List<IValidationRule<T>>();
            this.ValidationGroups = new Dictionary<string, IList<IValidationRule<T>>>();
        }

        public void AddRule(IValidationRule<T> rule)
        {
            this.ValidationRules.Add(rule);
        }

        public void AddRule(string group, IValidationRule<T> rule)
        {
            if (!this.ValidationGroups.ContainsKey(group))
            {
                this.ValidationGroups.Add(group, new List<IValidationRule<T>>());
            }

            this.ValidationGroups[group].Add(rule);
        }


        public IValidationResult Validate(T obj)
        {
            var result = new ValidationResult();

            foreach (IValidationRule<T> rule in this.ValidationRules)
            {
                if (rule.IsSatisfiedBy(obj) == false)
                {
                    result.AddError(rule.GetError());
                }
            }

            foreach (KeyValuePair<string, IList<IValidationRule<T>>> group in this.ValidationGroups)
            {
                foreach (IValidationRule<T> rule in group.Value)
                {
                    if (rule.IsSatisfiedBy(obj) == false)
                    {
                        result.AddError(rule.GetError());
                        break;
                    }
                }
            }

            return result;
        }


        public IValidationResult Validate(IEnumerable<T> objList)
        {
            var result = new ValidationResult();

            int i = 0;
            foreach (T obj in objList)
            {
                var validation = this.Validate(obj);

                if (validation.IsValid == false)
                {
                    foreach (IValidationError error in validation.Errors)
                    {
                        result.AddError(new ValidationError(string.Format("[{0}].{1}", i, error.PropertyName), error.Message));
                    }
                }

                i++;
            }

            return result;
        }

    }
}
