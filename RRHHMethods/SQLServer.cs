using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace RRHHMethods
{
    public class SQLServer
    {
        //public readonly IConfiguration Configuration;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

       
        /*
        public SQLServer(IConfiguration config)
        {
          //  Configuration = config;
        }
        */
        public string ReadOneValue(string Command)
        {
            return ReadOneValue(Command, null);
        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public string ReadOneValue(string Command, SqlParameterCollection sqlParameterCollection)
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(GetConnectionStringByName("ConnectionString"));
            try
            {
                using (sqlCommand = new SqlCommand(Command, sqlConnection))
                {
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.Add(sqlParameterCollection);
                    string sReturnValue = null;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        sReturnValue = sqlDataReader.GetValue(0).ToString();
                    }
                    if (sqlDataReader != null && !sqlDataReader.IsClosed)
                        sqlDataReader.Close();
                    return sReturnValue;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }

        public List<T> ReadValueSP<T>(string Command, List<SqlParameter> sqlParameterCollection)
        {
            DataTable dtLista = new DataTable();
            DataSet dtsLista = new DataSet();
            List<T> listValues;

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(GetConnectionStringByName("ConnectionString"));
            try
            {
                using (sqlCommand = new SqlCommand(Command, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    sqlConnection.Open();

                    listValues = new List<T>();

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
                    sqlDA.Fill(dtsLista, "valores");
                    dtLista = dtsLista.Tables[0];

                    listValues = FuncionesDB.ConvertDataTable<T>(dtLista);
                    return listValues;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }

        public DataSet ReadValueSPTables<T>(string Command, List<SqlParameter> sqlParameterCollection)
        {
            DataTable dtLista = new DataTable();
            DataSet dtsLista = new DataSet();
            List<T> listValues;

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(GetConnectionStringByName("ConnectionString"));
            try
            {
                using (sqlCommand = new SqlCommand(Command, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    sqlConnection.Open();

                    listValues = new List<T>();

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
                    sqlDA.Fill(dtsLista, "valores");
                    return dtsLista;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }

        public SqlDataReader CRUDValues(string Command, List<SqlParameter> sqlParameterCollection)
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(GetConnectionStringByName("ConnectionString"));
            try
            {
                using (sqlCommand = new SqlCommand(Command, sqlConnection))
                {
                    if (sqlParameterCollection != null)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    }
                    sqlConnection.Open();

                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    return dr;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
        }

        public void CerrarConexion()
        {
            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                sqlConnection.Close();
        }

        public void abrirConexion()
        {
            sqlConnection.Open();
        }

        public string ObtenerIP()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }

            return localIP;
        }
    }
}
