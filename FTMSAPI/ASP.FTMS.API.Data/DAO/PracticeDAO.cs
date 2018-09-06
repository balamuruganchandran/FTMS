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
    public class PracticeDAO:IPracticeDAO
    {
        private readonly DataAccess.Interface.IDataAccessFactory dataAccessFactory;

        
        public PracticeDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }

        public async Task<Practice> GetPracticeByPracticeId(int practiceID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PracticeID", practiceID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<Practice>("Comm.spPracticeByPracticeId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<Practice>> GetAllPractice()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<Practice>("Comm.spPracticeSelectAll", commandType: CommandType.StoredProcedure);

            }
        }

    }
}
