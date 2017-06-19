using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation.Rules.UsuarioRules
{
    public class UsuarioNomeTemAte70CaracteresRule : IValidationRule<Usuario>
    {

        public bool IsSatisfiedBy(Usuario obj)
        {
            return obj.Nome.Length <= 70;
        }

        public IValidationError GetError()
        {
            return new ValidationError("Nome", "O campo deve ter até 70 caracteres.");
        }

    }
}
