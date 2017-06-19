using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation.Rules.UsuarioRules
{
     public class UsuarioNomeObrigatorioRule : IValidationRule<Usuario>
    {

        public bool IsSatisfiedBy(Usuario obj)
        {
            return string.IsNullOrWhiteSpace(obj.Nome) == false;
        }

        public IValidationError GetError()
        {
            return new ValidationError("Nome", "O campo nome é obrigatório.");
        }

    }
}
