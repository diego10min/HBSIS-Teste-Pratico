using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Repository.Helper
{
    public class ProcedureSql
    {
        public string Name { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public ProcedureSql()
        {
            this.Parameters = new List<SqlParameter>();
        }

        public ProcedureSql(string name)
            : this()
        {
            this.Name = name;
        }

        public void AddParameter(string name, object value)
        {
            this.Parameters.Add(new SqlParameter(name, value));
        }

        public void AddParameter(string name, SqlDbType sqlDbType, ParameterDirection direction)
        {
            this.Parameters.Add(new SqlParameter() { ParameterName = name, SqlDbType = sqlDbType, Direction = direction });
        }

        public void AddParameter(string name, object value, SqlDbType sqlDbType)
        {
            this.Parameters.Add(new SqlParameter() { ParameterName = name, SqlDbType = sqlDbType, Value = value });
        }

        public List<T> GetList<T>(Func<SqlDataReader, T> createObjectFunction)
        {
            var list = new List<T>();

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = this.Name;


                foreach (SqlParameter parameter in this.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(createObjectFunction(reader));
                }
            }

            return list;
        }

        public T Get<T>(Func<SqlDataReader, T> createObjectFunction)
        {
            T obj = default(T);

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = this.Name;


                foreach (SqlParameter parameter in this.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    obj = createObjectFunction(reader);
                }
            }

            return obj;
        }

        public bool? GetBoolean()
        {
            bool? obj = null;

            using (var connection = SqlHelper.GetConnection())
            {

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = this.Name;


                foreach (SqlParameter parameter in this.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    obj = reader.GetBoolean(0);
                }
            }

            return obj;
        }

        public void Execute()
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = this.Name;
                command.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in this.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
            }
        }

        public int Insert(string key = "@IdRetorno", bool keyAsOutputParameter = true)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = this.Name;


                if (keyAsOutputParameter)
                {
                    this.AddParameter(key, SqlDbType.Int, ParameterDirection.Output);
                }

                foreach (SqlParameter parameter in this.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();

                return Convert.ToInt32(command.Parameters[key].Value);
            }
        }

    }
}
