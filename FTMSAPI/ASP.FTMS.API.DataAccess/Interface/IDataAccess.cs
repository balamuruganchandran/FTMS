using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.DataAccess.Interface
{
    public interface IDataAccess : IDisposable
    {
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        IEnumerable<T> QueryAsync1<T>(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));
        DbTransaction BeginTransaction();

        void Rollback();
        void Commit();

    }
}
