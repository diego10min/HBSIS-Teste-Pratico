using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Factories
{
    public static class RepositoryFactory
    {

        public static IUsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }

    }
}
