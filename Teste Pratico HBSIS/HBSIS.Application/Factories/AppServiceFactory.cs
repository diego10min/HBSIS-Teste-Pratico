using HBSIS.Application.Contracts;
using HBSIS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Factories
{
    public static class AppServiceFactory
    {
        public static IUsuarioAppService ObterUsuarioAppService()
        {
            return new UsuarioAppService(ServiceDomainFactory.ObterUsuarioService());
        }
    }
}
