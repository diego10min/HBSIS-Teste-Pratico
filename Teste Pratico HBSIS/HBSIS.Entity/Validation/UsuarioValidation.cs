using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using HBSIS.Entity.Validation.Rules.UsuarioRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Validation
{
    public class UsuarioValidation : ValidationEngine<Usuario>, IUsuarioValidation 
    {

        public UsuarioValidation(IUsuarioRepository repository)
        {
            this.AddRule("Nome", new UsuarioNomeObrigatorioRule());
            this.AddRule("Nome", new UsuarioNomeTemAte70CaracteresRule());
            this.AddRule("Telefone", new UsuarioTelefoneValido());
            this.AddRule("Documento", new UsuarioCpfCnpjValidoRule());
        }

    }
}
