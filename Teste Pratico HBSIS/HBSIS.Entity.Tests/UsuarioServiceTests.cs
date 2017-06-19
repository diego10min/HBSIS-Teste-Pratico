using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HBSIS.Entity.Contracts.Repositories;
using HBSIS.Entity.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using HBSIS.Entity.Validation;
using HBSIS.Entity.Services;

namespace HBSIS.Entity.Tests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        [TestClass]
        public class AdicionarMethod
        {
            [TestMethod]
            public void Deve_adicionar_usuario_valido()
            {
                var repositorio = new FakeUsuarioRespository();
                var validacao = new UsuarioValidation(repositorio);
                var servico = new UsuarioService(repositorio, validacao);
                Usuario usuario = repositorio.GerarUsuarioValido();

                var resultado = servico.Adicionar(usuario);

                Assert.IsTrue(resultado.IsValid);
                Assert.IsTrue(resultado.Errors.Count == 0);
            }

            [TestMethod]
            public void Deve_retornar_erro_nome()
            {
                var repositorio = new FakeUsuarioRespository();
                var validacao = new UsuarioValidation(repositorio);
                var servico = new UsuarioService(repositorio, validacao);
                Usuario usuario = repositorio.GerarUsuarioValido();
                usuario.Nome = "";

                var resultado = servico.Adicionar(usuario);

                Assert.IsTrue(resultado.IsValid);
                Assert.IsTrue(resultado.Errors.Count == 0);
            }

            [TestMethod]
            public void Deve_retornar_erro_telefone()
            {
                var repositorio = new FakeUsuarioRespository();
                var validacao = new UsuarioValidation(repositorio);
                var servico = new UsuarioService(repositorio, validacao);
                Usuario usuario = repositorio.GerarUsuarioValido();
                usuario.Telefone = "";

                var resultado = servico.Adicionar(usuario);

                Assert.IsTrue(resultado.IsValid);
                Assert.IsTrue(resultado.Errors.Count == 0);
            }

            [TestMethod]
            public void Deve_retornar_erro_cpf_invalido()
            {
                var repositorio = new FakeUsuarioRespository();
                var validacao = new UsuarioValidation(repositorio);
                var servico = new UsuarioService(repositorio, validacao);
                Usuario usuario = repositorio.GerarUsuarioValido();
                usuario.Documento = "12345678988";

                var resultado = servico.Adicionar(usuario);

                Assert.IsTrue(resultado.IsValid);
                Assert.IsTrue(resultado.Errors.Count == 0);
            }
        }

        #region Ajudantes
        public class FakeUsuarioRespository : IUsuarioRepository
        {
            public Usuario GerarUsuarioValido()
            {
                var usuario = new Usuario();
                usuario.Nome = "José da Silva";
                usuario.Documento = "12345678909";
                usuario.Telefone = "19999999999";
                return usuario;
            }

            public List<Usuario> Usuarios { get; set; }

            public FakeUsuarioRespository()
            {
                this.Usuarios = new List<Usuario>();
            }

            public void Adicionar(Usuario entity)
            {
                entity.Id_Usuario = this.Usuarios.Count + 1;
                this.Usuarios.Add(entity);
            }

            public void Atualizar(Usuario usuarioAtualizado)
            {
                var usuarioExistente = this.ObterPorId(usuarioAtualizado.Id_Usuario);

                if (usuarioExistente != null)
                {
                    int indice = this.Usuarios.IndexOf(usuarioExistente);
                    this.Usuarios[indice] = usuarioAtualizado;
                }
            }

            public void Remover(int codigo)
            {
                throw new NotImplementedException();
            }

            public Usuario ObterPorId(int codigo)
            {
                foreach (Usuario usuario in this.Usuarios)
                {
                    if (usuario.Id_Usuario == codigo)
                        return usuario;
                }

                return null;
            }

            public List<Usuario> ListarTodos()
            {
                if (this.Usuarios != null && this.Usuarios.Count > 0)
                    return this.Usuarios;
                else
                {
                    return null;
                }

            }


        }
        #endregion
    }
}
