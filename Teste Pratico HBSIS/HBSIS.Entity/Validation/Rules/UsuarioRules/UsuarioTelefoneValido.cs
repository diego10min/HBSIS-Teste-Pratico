using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation.Rules.UsuarioRules
{
    public class UsuarioTelefoneValido : IValidationRule<Usuario>
    {

        public bool IsSatisfiedBy(Usuario obj)
        {
            if (obj.Telefone == null)
                return false;

            return obj.Telefone.Length >= 10 && obj.Telefone.Length <= 11;
        }

        public IValidationError GetError()
        {
            return new ValidationError("Telefone", "Telefone Inválido");
        }

    }
}
