using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using ASP.FTMS.API.DataAccess;
using System.Data.Common;
using ASP.FTMS.API.DataAccess.Interface;

namespace ASP.FTMS.API.DataAccess
{
public class DataAccess:IDataAccess
    {
        private string connectionString;
        private DbConnection connection;
        private DbCommand command;
        private DbTransaction transaction;
        private readonly DbProviderFactory factory;
        public DataAccess(string providerName, string connectionString)
        {
            this.connectionString = connectionString;
            this.factory = DbProviderFactories.GetFactory(providerName);

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                if (this.connection == null)
                {
                    this.connection = this.factory.CreateConnection();
                    this.connection.ConnectionString = this.connectionString;
                }
                if (this.command == null)
                    this.command = this.factory.CreateCommand();
            }
            catch (Exception ex)
            {
            }

        }
  
        public async Task<int> ExecuteAsync(string sql, object param , int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            try
            {         
                return await connection.ExecuteAsync(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);               
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        public  IEnumerable<T> QueryAsync1<T>(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            var result = connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType).Result;
            //try
            //{
            //    var result = await Task.Run(() =>
            //    {
            //        return connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType).GetAwaiter().GetResult();
            //    });
            //    //var result= await connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);
             return result;

            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        }
       
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {


            var re=  await connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);
            return re;
            //try
            // return await connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);
            //try
            //{
            //    var result = await Task.Run(() =>
            //    {
            //        return connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType).GetAwaiter().GetResult();
            //    });
            //    //var result= await connection.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);


            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        }
        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param=null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return await connection.QuerySingleOrDefaultAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType == null ? CommandType.StoredProcedure : commandType);
        }


        public DbTransaction BeginTransaction()
        {
            this.OpenConnectionIfClosed();

            this.transaction = this.connection.BeginTransaction();
            this.command.Transaction = this.transaction;

            return this.transaction;
        }

        private void OpenConnectionIfClosed()
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
        }

        public void Rollback()
        {
            if (this.transaction != null)
                this.transaction.Rollback();
        }

        public void Commit()
        {
            if (this.transaction != null)
                this.transaction.Commit();
        }

        public void Dispose()
        {
            // dispose of the managed and unmanaged resources
            this.Dispose(true);

            // tell the GC that the Finalize process no longer needs
            // to be run for this object.
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        public void Dispose(bool disposeManagedResources)
        {
            if (!this._disposed)
            {
                if (disposeManagedResources)
                {
                    if (this.connection != null)
                    {
                        if (this.connection.State != ConnectionState.Closed)
                            this.connection.Close();

                        this.connection.Dispose();
                    }
                }
            }
            this._disposed = true;
        }
    }


}
