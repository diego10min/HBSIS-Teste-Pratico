using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation
{
    public class ValidationError : IValidationError
    {
        public string Message { get; private set; }
        public string PropertyName { get; private set; }

        public ValidationError(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;
        }
    }

    public class ValidationError<T> : IValidationError
    {
        public string Message { get; private set; }
        public string PropertyName { get; private set; }

        public ValidationError(Expression<Func<T, object>> property, string message)
        {
            this.PropertyName = this.GetPropertyName(property);
            this.Message = message;
        }

        private string GetPropertyName(Expression<Func<T, object>> property)
        {
            if (property == null)
                throw new NullReferenceException("The parameter property is null.");

            if (property.Body is MemberExpression)
            {
                return ((MemberExpression)property.Body).Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)property.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

    }
}
