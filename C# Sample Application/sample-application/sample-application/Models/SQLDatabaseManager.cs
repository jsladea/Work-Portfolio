using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.config;

namespace sampleApp.Models
{
    public class SQLDatabaseManager : DatabaseManager
    {

        private SqlCredential credential;
        private string connectionString;

        /// <summary>
        /// Default Constructor that sets up the connection based on the 
        /// </summary>
        public SQLDatabaseManager() => SetUpConnection();

        public SQLDatabaseManager(SqlCredential credential)
        {
            SetUpConnection();
            this.credential = credential;
        }

        private void SetUpConnection() => connectionString = ApplicationState.IsDebug ? config.SQLServerInfo.SQLTestServerConnectionString : config.SQLServerInfo.SQLServerConnectionString;
  

        public override async Task<DataTable> ExecuteQueryAsync(string query, ParameterList parameterList = null)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlCommand cmd = parameterList != null ? CreateCommand(query, parameterList, connection) : new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        await connection.OpenAsync();
                        await Task.Run(() => 
                        {
                            try
                            {
                                adapter.Fill(dataSet);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception while executing query in SQLDB");
                                Console.WriteLine("\n\n" + query + "\n");
                                throw ex;
                            }
                        });
                        return dataSet.Tables[0];
                    }
                }
            }
        }

        public override async Task<int> ExecuteNonQueryAsync(string cmdText, ParameterList parameterList)
        {

            using (SqlConnection connection = GetDbConnection())
            {

                using (SqlCommand cmd = CreateCommand(cmdText, parameterList, connection))
                {
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public override async Task<int> ExecuteNonQueryAsync(string cmdText, object[] parameters)
        {
            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlCommand cmd = CreateCommand(cmdText, parameters, connection))
                {
                    await connection.OpenAsync();

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private SqlCommand CreateCommand(string cmdText, ParameterList parameterList, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;
            cmd.Connection = connection;
            foreach (Tuple<string, object> parameter in parameterList.Parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
            }
            return cmd;
        }

        private SqlCommand CreateCommand(string cmdText, object[] parameters, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;
            cmd.Connection = connection;
            for (int i = 0; i < parameters.Length; i++)
                cmd.Parameters.AddWithValue(i.ToString(), parameters[i]);

            return cmd;
        }

        protected override DbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private SqlConnection GetDbConnection()
        {
            return (SqlConnection)GetConnection();
        }

        #region methods for use in transactions
        public override async Task<int> TransExecuteNonQueryAsync(string cmdText, object[] parameters, DbTransaction transaction)
        {
            SqlTransaction dbTransaction = (SqlTransaction)transaction;
            using (SqlCommand cmd = CreateCommand(cmdText, parameters, dbTransaction.Connection))
            {
                cmd.Transaction = dbTransaction;
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public override async Task<int> TransExecuteNonQueryAsync(string cmdText, ParameterList parameterList, DbTransaction transaction)
        {
            SqlTransaction dbTransaction = (SqlTransaction)transaction;
            using (SqlCommand cmd = CreateCommand(cmdText, parameterList, dbTransaction.Connection))
            {
                cmd.Transaction = dbTransaction;
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public override async Task<DataTable> TransExecuteQueryAsync(string query, DbTransaction transaction, ParameterList parameterList = null)
        {
            DataSet dataSet = new DataSet();
            SqlTransaction dbTransaction = (SqlTransaction)transaction;
            using (SqlCommand cmd = parameterList != null ? CreateCommand(query, parameterList, dbTransaction.Connection) : new SqlCommand(query, dbTransaction.Connection))
            {
                cmd.Transaction = dbTransaction;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        await Task.Run(() => adapter.Fill(dataSet));
                        return dataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception while executing query");
                        throw ex;
                    }
                }
            }
        }
        #endregion
    }
}
