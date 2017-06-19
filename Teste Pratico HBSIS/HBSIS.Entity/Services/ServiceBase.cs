using HBSIS.Entity.Contracts.Model;
using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Entity.Contracts.Services;
using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : IEntity
    {
        protected IRepositoryBase<T> RepositoryBase { get; set; }
        protected IValidationEngine<T> ValidationBase { get; set; }

        public ServiceBase(IRepositoryBase<T> repository, IValidationEngine<T> validation)
        {
            this.RepositoryBase = repository;
            this.ValidationBase = validation;
        }


        public IValidationResult Adicionar(T entity)
        {
            var validationResult = this.ValidationBase.Validate(entity);

            if (validationResult.IsValid)
            {
                this.RepositoryBase.Adicionar(entity);
            }

            return validationResult;
        }

        public IValidationResult Atualizar(T entity)
        {
            var validationResult = this.ValidationBase.Validate(entity);

            if (validationResult.IsValid)
            {
                this.RepositoryBase.Atualizar(entity);
            }

            return validationResult;
        }

        public void Remover(int codigo)
        {
            this.RepositoryBase.Remover(codigo);
        }

        public T ObterPorId(int codigo)
        {
            return this.RepositoryBase.ObterPorId(codigo);
        }

        public List<T> ListarTodos()
        {
            return this.RepositoryBase.ListarTodos();
        }
    }
}
