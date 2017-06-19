using HBSIS.Entity.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(int id);
        T ObterPorId(int id);
        List<T> ListarTodos();
    }
}
