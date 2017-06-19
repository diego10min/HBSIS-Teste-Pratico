using HBSIS.Entity.Common;
using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation.Rules.UsuarioRules
{
    public class UsuarioCpfCnpjValidoRule : IValidationRule<Usuario>
    {

        public bool IsSatisfiedBy(Usuario obj)
        {
            if (String.IsNullOrEmpty(obj.Documento))
                return false;

            if (obj.Documento.Length >= 14)
            {
                return ValidacoesComuns.ValidarCnpj(obj.Documento);
            }else{
                return ValidacoesComuns.ValidarCpf(obj.Documento);
            }
            
        }

        public IValidationError GetError()
        {
            return new ValidationError("Documento", "Documento inválido.");
        }

    }
}
