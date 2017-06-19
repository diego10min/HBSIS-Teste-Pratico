using HBSIS.Entity.Contracts.Model;
using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Contracts.Services
{
    public interface IServiceBase<T> where T : IEntity
    {
        IValidationResult Adicionar(T entity);
        IValidationResult Atualizar(T entity);
        void Remover(int id);
        T ObterPorId(int id);
        List<T> ListarTodos();
    }
}
