using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Entity.Contracts.Services;
using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {

        private IUsuarioRepository Repository { get; set; }
        private IUsuarioValidation UsuarioValidation { get; set; }


        public UsuarioService(IUsuarioRepository repository, IUsuarioValidation validation)
            : base(repository, validation)
        {
            this.Repository = repository;
            this.UsuarioValidation = validation;
        }

    }
}
