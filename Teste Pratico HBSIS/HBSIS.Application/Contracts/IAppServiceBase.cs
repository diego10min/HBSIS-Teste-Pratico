using HBSIS.Entity.Contracts.Model;
using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Application.Contracts
{
    public interface IAppServiceBase<T> where T : IEntity
    {
        IValidationResult Adicionar(T obj);
        IValidationResult Atualizar(T obj);
        void Remover(int id);
        T ObterPorId(int id);
        List<T> ListarTodos();
    }
}
