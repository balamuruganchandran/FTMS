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
   public class AssignmentTypeDAO:IAssignmentTypeDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;

       
        public AssignmentTypeDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }
        
        public async Task<AssignmentType> GetAssignmentTypeByAssignmentTypeId(int assignmentTypeID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AssignmentTypeID", assignmentTypeID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<AssignmentType>("Comm.spAssignmentTypeByAssignmentTypeId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<AssignmentType>> GetAllAssignmentType()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<AssignmentType>("Comm.spAssignmentTypeSelectAll", commandType: CommandType.StoredProcedure);

            }
        }
    }
}
