using HBSIS.Application.Contracts;
using HBSIS.Entity.Contracts.Services;
using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Services
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private IUsuarioService UsuarioService { get; set; }

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            this.UsuarioService = usuarioService;
        }

    }
}
