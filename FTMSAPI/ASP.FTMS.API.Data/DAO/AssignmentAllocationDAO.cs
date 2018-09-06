using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.DataAccess;
using ASP.FTMS.API.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.FTMS.API.Data.Models.Entity;
using Dapper;
using System.Data;
using ASP.FTMS.API.Data.Models.Response;

namespace ASP.FTMS.API.Data.DAO
{
   public class AssignmentAllocationDAO:IAssignmentAllocationDAO
    {
        IDataAccessFactory dataAccessFactory;
        public AssignmentAllocationDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }

        public async Task<int> AllocateAssignment(AssignmentAllocation assignmentAllocation)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@AssignmentID", assignmentAllocation.AssignmentID, DbType.Int32, ParameterDirection.Input);
                param.Add("@MemberID", assignmentAllocation.MemberID, DbType.Int32, ParameterDirection.Input);
                param.Add("@RequiredUnit", assignmentAllocation.RequiredUnit, DbType.Byte, ParameterDirection.Input);
                param.Add("@PeriodUnitID", assignmentAllocation.PeriodUnitID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ProposedStartDate", assignmentAllocation.ProposedStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ProposedEndDate", assignmentAllocation.ProposedEndDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ActualStartDate", assignmentAllocation.ActualStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ActualEndDate", assignmentAllocation.ActualEndDate, DbType.Date, ParameterDirection.Input);
                param.Add("@AllocationStatusID", assignmentAllocation.AllocationStatusID, DbType.Byte, ParameterDirection.Input);
                param.Add("@AddedUser", assignmentAllocation.AddedUser, DbType.String, ParameterDirection.Input,30);
                param.Add("@AssignmentAllocationID", assignmentAllocation.AssignmentAllocationID, DbType.Int32, ParameterDirection.Output);

                try
                {

                    var sfd= await dataAccessObj.ExecuteAsync("Assi.spAssignmentAllocationInsert", param, commandType: CommandType.StoredProcedure);
                    var hy= param.Get<int>("@AssignmentAllocationID");
                    return hy;
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
               
        }

        public async Task<IEnumerable<AssignmentAllocationDetails>> GetAllAssignmentAllocation()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return await dataAccessObj.QueryAsync<AssignmentAllocationDetails>("spAssignmentAllocationSelectAll", CommandType.StoredProcedure);
            }
        }
        public async Task<AssignmentAllocationDetails> GetAssignmentAllocationByAllocationId(int assignmentAllocationID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return await dataAccessObj.QuerySingleOrDefaultAsync<AssignmentAllocationDetails>("spAssignmentAllocationSelectByAllocationId", CommandType.StoredProcedure);
            }
        }

        public async Task<int> ModifyAssignmentAllocation(AssignmentAllocation assignmentAllocation)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@AssignmentID", assignmentAllocation.AssignmentID, DbType.Int32, ParameterDirection.Input);
                param.Add("@MemberID", assignmentAllocation.MemberID, DbType.Int32, ParameterDirection.Input);
                param.Add("@RequiredUnit", assignmentAllocation.RequiredUnit, DbType.Byte, ParameterDirection.Input);
                param.Add("@PeriodUnitID", assignmentAllocation.PeriodUnitID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ProposedStartDate", assignmentAllocation.ProposedStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ProposedEndDate", assignmentAllocation.ProposedEndDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ActualStartDate", assignmentAllocation.ActualStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ActualEndDate", assignmentAllocation.ActualEndDate, DbType.Date, ParameterDirection.Input);
                param.Add("@AllocationStatusID", assignmentAllocation.AllocationStatusID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ModifiedUser", assignmentAllocation.AddedUser, DbType.String, ParameterDirection.Input, 30);
                param.Add("@AssignmentAllocationID", assignmentAllocation.AssignmentAllocationID, DbType.Int32, ParameterDirection.Output);
                param.Add("@Returnvalue", dbType:DbType.Int32, direction:ParameterDirection.ReturnValue);

                try
                {

                     await dataAccessObj.ExecuteAsync("spAssignmentAllocationUpdate", param, commandType: CommandType.StoredProcedure);
                    return param.Get<int>("@Returnvalue");
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}
