using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestDemo
{
    public class SqlDataBind
    {
        public static int SaveDataByStoredProcedure(string procedureName, string connectionStringName, IEnumerable<Tuple<string, string>> parametersList = null)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
            int result = 0;
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedureName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parametersList != null)
                {
                    foreach (var item in parametersList)
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue(item.Item1, item.Item2);
                }
                result = sqlDataAdapter.SelectCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
                //Do something
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed && sqlConnection.State != ConnectionState.Broken)
                    sqlConnection.Close();
            }
            return result;
        }
        public static DataSet GetDataByStoredProcedure(string procedureName, string connectionStringName, IEnumerable<Tuple<string, string>> parametersList = null)
        {
            DataSet result = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedureName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parametersList != null)
                    foreach (var item in parametersList)
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue(item.Item1, item.Item2);
                sqlDataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                //Do Something
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed && sqlConnection.State != ConnectionState.Broken)
                    sqlConnection.Close();
            }
            return result;
        }
    }
}