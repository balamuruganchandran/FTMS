using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.DataAccess;
using ASP.FTMS.API.DataAccess.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO
{
    public class PeriodUnitDAO: IPeriodUnitDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;
    
        public PeriodUnitDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }

        public async Task<PeriodUnit> GetPeriodUnitByPeriodUnitID(int periodUnitID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PeriodUnitID", periodUnitID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<PeriodUnit>("Comm.spPeriodUnitByPeriodUnitId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<PeriodUnit>> GetAllperiodUnit()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<PeriodUnit>("Comm.spPeriodUnitSelectAll", commandType: CommandType.StoredProcedure);

            }
        }

    }
}
