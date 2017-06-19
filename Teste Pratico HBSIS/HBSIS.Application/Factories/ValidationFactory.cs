using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Factories
{
    public static class ValidationFactory
    {

        public static IUsuarioValidation ObterUsuarioValidation()
        {
            return new UsuarioValidation(RepositoryFactory.ObterUsuarioRepository());
        }

    }
}
