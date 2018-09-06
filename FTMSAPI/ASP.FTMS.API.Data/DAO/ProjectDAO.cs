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
    public class ProjectDAO : IProjectDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;    
        public ProjectDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }

        public async Task<Project> GetProjectByProjectId(int projectID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProjectID", projectID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<Project>("Comm.spProjectByProjectId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<Project>> GetAllProject()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<Project>("Comm.spProjectSelectAll", commandType: CommandType.StoredProcedure);

            }
        }

    }
}
