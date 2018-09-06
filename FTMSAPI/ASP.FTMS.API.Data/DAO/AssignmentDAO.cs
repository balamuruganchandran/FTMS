using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.Data.Models.Entity;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ASP.FTMS.API.DataAccess.Interface;
using System;
using ASP.FTMS.API.DataAccess;
using ASP.FTMS.API.Data.Models.Response;

namespace ASP.FTMS.API.Data.DAO
{
   public class AssignmentDAO:IAssignmentDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;
        public AssignmentDAO()
        {
           this.dataAccessFactory = new DataAccessFactory();
        }
         
        public async Task<int> AddAssignmentAsync(Assignment assignment)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Title", assignment.Title, DbType.String, ParameterDirection.Input, 100);
                param.Add("@Description", assignment.Description, DbType.String, ParameterDirection.Input, 1000);

                param.Add("@MemberID", assignment.MemberID, DbType.Int32, ParameterDirection.Input);
                param.Add("@ProjectID", assignment.ProjectID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ProposedUnit", assignment.ProposedUnit, DbType.Byte, ParameterDirection.Input);
                param.Add("@PeriodUnitID", assignment.PeriodUnitID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ProposedStartDate", assignment.ProposedStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ProposedEndDate", assignment.ProposedEndDate, DbType.Date, ParameterDirection.Input);

                param.Add("@AssignmetStatusID", assignment.AssignmentStatusID, DbType.Byte, ParameterDirection.Input);
                param.Add("@AssignmentTypeID", assignment.AssignmentTypeID, DbType.Byte, ParameterDirection.Input);
                param.Add("@PracticeID", assignment.PracticeID, DbType.Byte, ParameterDirection.Input);
                param.Add("@AddedUser", assignment.AddedUser, DbType.String, ParameterDirection.Input, 30);
                param.Add("@AssignmentID", assignment.AssignmentID, DbType.Int32, ParameterDirection.Output);
                try
                {
                    
                      await dataAccessObj.ExecuteAsync("Assi.spAssignmentInsert", param, commandType: CommandType.StoredProcedure);
                      return param.Get<int>("AssignmentID");

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        //public async Task<int> DeactivateAssignment(int assignmentID, string userName)
        //{
        //    using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@AssignmentId", assignmentID,DbType.Byte,ParameterDirection.Input);
        //        param.Add("@ModifiedUser", userName, DbType.String, ParameterDirection.Input, 30);
        //        param.Add("@Returnvalue", dbType: DbType.Int64, direction: ParameterDirection.ReturnValue);
        //         await dataAccessObj.ExecuteAsync("Assi.spAssignmentDeactivate", param, commandType: CommandType.StoredProcedure);
        //        return param.Get<int>("@Returnvalue");
        //    }
        //}

        public async Task<AssignmentDetails> GetAssignmentByAssignmentId(int assignmentID)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AssignmentId", assignmentID, DbType.Byte, ParameterDirection.Input);
                return await dataAccessObj.QuerySingleOrDefaultAsync<AssignmentDetails>("Assi.spAssignmentSelectByAssignmentId", param, commandType: CommandType.StoredProcedure);                
            }
        }

        public async Task<IEnumerable<AssignmentDetails>> GetAllAssignments()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                try {
                    var re= await dataAccessObj.QueryAsync<AssignmentDetails>("Assi.spAssignmentSelectAll", commandType: CommandType.StoredProcedure);
                    return re;
                }
                catch(Exception e)
                {
                    return null;
                }

            }
        }
        public IEnumerable<AssignmentDetails> GetAllAssignments1()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                try
                {
                    var re =  dataAccessObj.QueryAsync1<AssignmentDetails>("Assi.spAssignmentSelectAll", commandType: CommandType.StoredProcedure);
                    return re;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public async Task<int> ModifyAssignment(Assignment assignment)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AssignmentID", assignment.AssignmentID, DbType.Int32, ParameterDirection.Input);
                param.Add("@ProposedUnit", assignment.ProposedUnit, DbType.Byte, ParameterDirection.Input);
                param.Add("@PeriodUnitID", assignment.PeriodUnitID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ProposedStartDate", assignment.ProposedStartDate, DbType.Date, ParameterDirection.Input);
                param.Add("@ProposedEndDate", assignment.ProposedEndDate, DbType.Date, ParameterDirection.Input);
                param.Add("@AssignmetStatusID", assignment.AssignmentStatusID, DbType.Byte, ParameterDirection.Input);
                param.Add("@AssignmentTypeID", assignment.AssignmentTypeID, DbType.Int32, ParameterDirection.Input);
                param.Add("@ModifiedUser", assignment.ModifiedUser, DbType.Int64, ParameterDirection.Input);
                param.Add("@Active", assignment.Active, DbType.Boolean, ParameterDirection.Input);
                param.Add("@Returnvalue",dbType: DbType.Int64, direction:ParameterDirection.ReturnValue);
                await dataAccessObj.ExecuteAsync("Assi.spAssignmentUpdate", param, commandType: CommandType.StoredProcedure);
                return param.Get<int>("@Returnvalue");
                 
            }
            
        }
    }
}
