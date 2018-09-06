using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.DataAccess.Interface;
using ASP.FTMS.API.DataAccess;
using System;

namespace ASP.FTMS.API.Data.DAO
{
public class MemberDAO:IMemberDAO
    {
        private readonly IDataAccessFactory dataAccessFactory;
        
        public MemberDAO()
        {
            this.dataAccessFactory = new DataAccessFactory();
        }
       
        public Task<int> AddMember(Member member)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACEID", member.ACEID, DbType.String, ParameterDirection.Input, 10);
                param.Add("@ADUserName", member.ADUserName, DbType.String, ParameterDirection.Input, 70);
                param.Add("@FirstName", member.FirstName, DbType.String, ParameterDirection.Input, 20);
                param.Add("@LastName", member.LastName, DbType.String, ParameterDirection.Input, 20);
                param.Add("@EmailID", member.EmailId, DbType.String, ParameterDirection.Input, 70);
                param.Add("@Password", member.Password, DbType.String, ParameterDirection.Input, 15);
                param.Add("@PhoneNumber", member.PhoneNumber, DbType.String, ParameterDirection.Input, 10);

                param.Add("@BatchID", member.Batch.BatchID, DbType.Byte, ParameterDirection.Input);
                param.Add("@PracticeID", member.Practice.PracticeID, DbType.Byte, ParameterDirection.Input);

                param.Add("@RoleID", member.Roles.RoleID, DbType.Byte, ParameterDirection.Input);
                param.Add("@AddedUser", member.AddedUser, DbType.String, ParameterDirection.Input, 30);
                param.Add("@MemberID", member.MemberID, DbType.Int64, ParameterDirection.Output);

                try
                {
                    Task<int> count = dataAccessObj.ExecuteAsync("Memb.spMemberInsert", param, commandType: CommandType.StoredProcedure);
                    return count;
                }
                catch (Exception e)
                {
                   
                    return null;
                }

            }
        }

        public Task<int> DeactivateMember(int memberID, string userName)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MemberId", memberID);
                param.Add("@ModifiedUser", userName);

                return dataAccessObj.ExecuteAsync("Memb.spMemberDeactivate", param, commandType: CommandType.StoredProcedure);
            }

        }

        public Task<IEnumerable<Member>> GetAll()
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                return dataAccessObj.QueryAsync<Member>("Memb.spMemberSelect", commandType: CommandType.StoredProcedure);

            }
        }

        public Task<int> UpdateMember(Member member)
        {
            using (var dataAccessObj = dataAccessFactory.CreateDBInstance().Create())
            {
                DynamicParameters param = new DynamicParameters();
            
                param.Add("@ADUserName", member.ADUserName, DbType.String, ParameterDirection.Input, 70);      
                param.Add("@Password", member.Password, DbType.String, ParameterDirection.Input, 15);
                param.Add("@PhoneNumber", member.PhoneNumber, DbType.String, ParameterDirection.Input, 10);
                param.Add("@BatchID", member.Batch.BatchID, DbType.Byte, ParameterDirection.Input);
                param.Add("@PracticeID", member.Practice.PracticeID, DbType.Byte, ParameterDirection.Input);
                param.Add("@ModifiedUser", member.AddedUser, DbType.String, ParameterDirection.Input, 30);
              
                return dataAccessObj.ExecuteAsync("Memb.spMemberUpdate", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

