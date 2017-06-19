using HBSIS.Entity.Contracts.Services;
using HBSIS.Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Factories
{
    public static class ServiceDomainFactory
    {

        public static IUsuarioService ObterUsuarioService()
        {
            return new UsuarioService(RepositoryFactory.ObterUsuarioRepository(), ValidationFactory.ObterUsuarioValidation());
        }

    }
}
