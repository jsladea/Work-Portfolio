using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace sampleApp.Models
{
    public abstract class DatabaseManager
    { 

        public delegate Task<int> TransactionDelegateInt(DatabaseManager dbManager, DbTransaction transaction, object inputData = null);
        public delegate Task<DataTable> TransactionDelegateTable(DatabaseManager dbManager, DbTransaction transaction, object inputData = null);

        /// <summary>
        /// Executes a command to the Database
        /// </summary>
        /// <param name="cmdText">SQL command</param>
        /// <param name="parameters">object[] of parameters</param>
        /// <returns>The number of rows affected by the operation</returns>
        public abstract Task<int> ExecuteNonQueryAsync(string cmdText, object[] parameters);

        /// <summary>
        /// Executes a command to the Database
        /// </summary>
        /// <param name="cmdText">SQL command</param>
        /// <param name="parameterList">ParameterList of parameters in the command</param>
        /// <returns>The number of rows affected by the operation</returns>
        public abstract Task<int> ExecuteNonQueryAsync(string cmdText, ParameterList parameterList);

        /// <summary>
        /// Executes a query against the Database
        /// </summary>
        /// <param name="query">query to execute</param>
        /// <param name="parameterList">ParameterList of parameters in the query</param>
        /// <returns>A DataTable containing the result set of the query</returns>
        public abstract Task<DataTable> ExecuteQueryAsync(string query, ParameterList parameterList = null);

        /// <summary>
        /// Method for use ONLY in transactions by the DatabaseManager to execute a command
        /// </summary>
        /// <returns>The number of rows affected by the operation</returns>
        public abstract Task<int> TransExecuteNonQueryAsync(string cmdText, object[] parameters, DbTransaction transaction);

        /// <summary>
        /// Method for use ONLY in transactions by the DatabaseManager to execute a command
        /// </summary>
        /// <returns>The number of rows affected by the operation</returns>
        public abstract Task<int> TransExecuteNonQueryAsync(string cmdText, ParameterList parameterList, DbTransaction transaction);

        /// <summary>
        /// Method for use ONLY in transactions by the DatabaseManager to execute a query against the Database
        /// </summary>
        /// <returns>A DataTable containing the result set of the query</returns>
        public abstract Task<DataTable> TransExecuteQueryAsync(string query, DbTransaction transaction, ParameterList parameterList = null);

        /// <summary>
        /// Gets a connection to the Database
        /// </summary>
        /// <returns>A DbConnection object</returns>
        protected abstract DbConnection GetConnection();


        /// <summary>
        /// Executes a transaction to the database
        /// </summary>
        /// <param name="transactionMethod">delegate method to execute</param>
        /// <returns>null if the transaction was unsuccessful</returns>
        public async Task<DataTable> ExecuteTransaction(TransactionDelegateTable transactionMethod, object inputData = null)
        {
            using (DbConnection connection = GetConnection())
            {
                await connection.OpenAsync();
                using (DbTransaction transaction = connection.BeginTransaction(config.DatabaseSettings.TransactionIsolation))
                {
                    try
                    {
                        DataTable resultTable;
                        if (inputData != null)
                            resultTable = await transactionMethod(this, transaction, inputData);
                        else
                            resultTable = await transactionMethod(this, transaction);
                        transaction.Commit();
                        return resultTable;
                    }
                    catch(Exception)
                    {
                        TryRollback(transaction);
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Executes a Transaction to the database
        /// </summary>
        /// <param name="transactionMethod">delegate method to execute</param>
        /// <returns>The result of the transaction</returns>
        public async Task<int> ExecuteTransaction(TransactionDelegateInt transactionMethod, object inputData = null)
        {
            using (DbConnection connection = GetConnection())
            {
                await connection.OpenAsync();
                using (DbTransaction transaction = connection.BeginTransaction(config.DatabaseSettings.TransactionIsolation))
                {
                    try
                    {
                        int result;
                        if (inputData != null)
                            result = await transactionMethod(this, transaction, inputData);
                        else
                            result = await transactionMethod(this, transaction);
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        TryRollback(transaction);
                        throw ex;
                        //return -1;
                    }
                }
            }
        }

        private void TryRollback(DbTransaction transaction)
        {
            Console.WriteLine("Exception thrown while executing transaction.");
            try //try to rollback the transaction
            {
                transaction.Rollback();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to rollback the transaction.");
            }
        }

        public class ParameterList
        {
            private List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

            /// <summary>
            /// Adds a parameter to the parameter list
            /// </summary>
            /// <param name="name">name of the parameter</param>
            /// <param name="value">value of the parameter</param>
            public void Add(string name, object value)
            {
                parameters.Add(new Tuple<string, object>(name, value));
            }

            public Tuple<string, object>[] Parameters => parameters.ToArray();
        }

    }
}
