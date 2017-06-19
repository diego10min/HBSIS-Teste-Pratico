using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Entity.Model;
using HBSIS.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Adicionar(Usuario entity)
        {
            var procedure = new ProcedureSql();
            procedure.Name = "CRUD_Usuario";
            procedure.AddParameter("@Acao", "I");
            procedure.AddParameter("@Nome", entity.Nome);
            procedure.AddParameter("@Telefone", entity.Telefone);
            procedure.AddParameter("@Documento", entity.Documento);
            entity.Id_Usuario = procedure.Insert(keyAsOutputParameter: true);
        }

        public void Atualizar(Usuario entity)
        {
            var procedure = new ProcedureSql();
            procedure.Name = "CRUD_Usuario";

            procedure.AddParameter("@Acao", "U");
            procedure.AddParameter("@IdUsuario", entity.Id_Usuario);
            procedure.AddParameter("@Nome", entity.Nome);
            procedure.AddParameter("@Telefone", entity.Telefone);
            procedure.AddParameter("@Documento", entity.Documento);
            procedure.AddParameter("@IdRetorno", SqlDbType.Int, ParameterDirection.Output);
            procedure.Execute();
        }

        public void Remover(int idUsuario)
        {
            var procedure = new ProcedureSql();
            procedure.Name = "CRUD_Usuario";

            procedure.AddParameter("@Acao", "D");
            procedure.AddParameter("@IdUsuario", idUsuario);
            procedure.AddParameter("@IdRetorno", SqlDbType.Int, ParameterDirection.Output);

            procedure.Execute();
        }

        public Usuario ObterPorId(int id)
        {
            var procedure = new ProcedureSql();
            procedure.Name = "Obter_Usuario";

            procedure.AddParameter("@Acao", "ID");
            procedure.AddParameter("@Valor1", id);

            return procedure.Get<Usuario>(PopularItem);
        }

        public List<Usuario> ListarTodos()
        {
            var procedure = new ProcedureSql();
            procedure.Name = "Listar_Usuario";

            procedure.AddParameter("@Acao", "TODOS");

            return procedure.GetList<Usuario>(PopularItem);
        }

        private Usuario PopularItem(SqlDataReader leitorSql)
        {
            Usuario usuario = new Usuario();
            usuario.Id_Usuario = leitorSql.GetInt32(0);
            usuario.Nome = leitorSql.GetString(1);
            usuario.Telefone = leitorSql.GetString(2);
            usuario.Documento = leitorSql.GetString(3);
            return usuario;
        }

    }
}
