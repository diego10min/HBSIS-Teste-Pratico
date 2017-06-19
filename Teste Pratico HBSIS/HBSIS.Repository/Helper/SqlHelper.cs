using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Repository.Helper
{
    public static class SqlHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionName = ConfigurationManager.ConnectionStrings["CurrentSqlServerConnection"].ConnectionString;

            if (string.IsNullOrEmpty(connectionName))
                throw new Exception("App setting with name CurrentSqlServerConnection not found in configuration file.");

            return GetConnection(connectionName);
        }

        public static SqlConnection GetConnection(string connectionName)
        {
            string connectionString = connectionName;

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception(string.Format("Connection string with name {0} not found.", connectionName));

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public static T GetValueOrDefault<T>(this SqlDataReader reader, int colIndex)
        {
            if (reader.IsDBNull(colIndex))
                return default(T);
            else
                return (T)Convert.ChangeType(reader.GetValue(colIndex), typeof(T));
        }


        public static T GetValueOrDefault<T>(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (reader.IsDBNull(colIndex))
                return default(T);
            else
                return (T)Convert.ChangeType(reader.GetValue(colIndex), typeof(T));
        }

    }
}
