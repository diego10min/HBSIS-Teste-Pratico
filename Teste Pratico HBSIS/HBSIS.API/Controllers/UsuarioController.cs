using HBSIS.Application.Contracts;
using HBSIS.Application.Factories;
using HBSIS.Entity.Contracts.Validation;
using HBSIS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HBSIS.API.Controllers
{
    public class UsuarioController : ApiController
    {
        public IUsuarioAppService UsuarioAppService { get; set; }

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            this.UsuarioAppService = usuarioAppService;
        }

        public UsuarioController()
            : this(AppServiceFactory.ObterUsuarioAppService())
        {

        }

        [HttpGet]
        public List<Usuario> Get()
        {
            List<Usuario> listaUsuario = this.UsuarioAppService.ListarTodos();

            if (listaUsuario != null && listaUsuario.Count > 0)
                return listaUsuario;
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpPost]
        [Route("api/usuario/edit")]
        public HttpResponseMessage PostEdit(Usuario usuario)
        {
            IValidationResult result = this.UsuarioAppService.Atualizar(usuario);

            if (result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.UsuarioAppService.ListarTodos());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result.Errors);
            }

        }

        [HttpPost]
        [Route("api/usuario/new")]
        public HttpResponseMessage PostNew(Usuario usuario)
        {
            IValidationResult result = this.UsuarioAppService.Adicionar(usuario);

            if (result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.UsuarioAppService.ListarTodos());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result.Errors);
            }
        }

        [HttpDelete]
        [Route("api/usuario/delete/{id}")]
        public void PostDelete(int id)
        {
            this.UsuarioAppService.Remover(id);
        }
    }
}