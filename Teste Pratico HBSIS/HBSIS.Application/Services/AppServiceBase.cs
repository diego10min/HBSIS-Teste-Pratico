using HBSIS.Application.Contracts;
using HBSIS.Entity.Contracts.Model;
using HBSIS.Entity.Contracts.Services;
using HBSIS.Entity.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace HBSIS.Application.Services
{
    public abstract class AppServiceBase<T> : IAppServiceBase<T> where T : IEntity
    {
        static string profileKey = "HBSIS:";
        
        protected IServiceBase<T> ServiceBase { get; set; }

        public AppServiceBase(IServiceBase<T> service)
        {
            this.ServiceBase = service;
        }

        public IValidationResult Adicionar(T obj)
        {
            IValidationResult validation = this.ServiceBase.Adicionar(obj);

            if (validation.IsValid)
                this.DeleteKeyFromCache(profileKey + "LISTA_TODOS");

            return validation;
        }

        public IValidationResult Atualizar(T obj)
        {
            IValidationResult validation = this.ServiceBase.Atualizar(obj);

            if (validation.IsValid)
                this.DeleteKeyFromCache(profileKey + "LISTA_TODOS");

            return validation;
        }

        public void Remover(int id)
        {
            this.ServiceBase.Remover(id);
            this.DeleteKeyFromCache(profileKey + "LISTA_TODOS");
        }

        public T ObterPorId(int id)
        {
            return this.ServiceBase.ObterPorId(id);
        }

        public List<T> ListarTodos()
        {
            string tipo = profileKey + "LISTA_TODOS";
            List<T> listarTodos = null;
            string list = GetValueFromCache(tipo);
            if (String.IsNullOrEmpty(list))
            {
                listarTodos = this.ServiceBase.ListarTodos();
                SetValueInCache(JsonConvert.SerializeObject(listarTodos), tipo);
            }
            else
                listarTodos = JsonConvert.DeserializeObject<List<T>>(list);

            return listarTodos;
        }

        private void DeleteKeyFromCache(string tipo)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            Type typeParameterType = typeof(T);
            string key = typeParameterType.FullName + "_" + tipo;
            cache.KeyDelete(key);

            this.ListarTodos();
        }

        private String GetValueFromCache(string tipo)
        {
            Type typeParameterType = typeof(T);
            string key = typeParameterType.FullName + "_" + tipo;

            var cache = RedisConnectorHelper.Connection.GetDatabase();
            string value = cache.StringGet(key);

            return value;
        }

        private void SetValueInCache(string valor, string tipo)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            Type typeParameterType = typeof(T);
            string key = typeParameterType.FullName + "_" + tipo;
            cache.StringSet(key, valor);
        }
    }
}
