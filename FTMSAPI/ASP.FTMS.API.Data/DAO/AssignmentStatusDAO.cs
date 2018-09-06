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
   public class AssignmentStatusDAO:IAssignmentStatusDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;

        
        public AssignmentStatusDAO()
        {
           this. dataAccessFactory = new DataAccessFactory();
        }
      

        public async Task<AssignmentStatus> GetAssignmentStatusByAssignmentStatusId(int assignmentStatusID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AssignmentStatusID", assignmentStatusID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<AssignmentStatus>("Comm.spAssignmentStatusSelectByAssignmentStatusId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<AssignmentStatus>> GetAllAssignmentStatus()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<AssignmentStatus>("Comm.spAssignmentStatusSelectAll", commandType: CommandType.StoredProcedure);

            }
        }
    }
}
