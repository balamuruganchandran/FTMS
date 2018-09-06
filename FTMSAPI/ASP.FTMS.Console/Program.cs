using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using System.Data;

using ASP.FTMS.WebAPI.Models.DTO;
using ASP.FTMS.WebAPI.Logic;
using ASP.FTMS.API.Data.DAO;
using ASP.FTMS.API.Data.Models.Entity;

namespace ASP.FTMS.Console
{
    class Program
    {
      
        private void CreateDbInstance()
        {

        }
        public async void AddMember()
        {
            Assignment assignment = new Assignment();
            //{
            //    Title = "hghgfhgf",
            //    Description = "jhgjhgfhgh",
            //    MemberID = 1,
            //    ProjectID = 1,
            //    ProposedUnit = 1,
            //    PeriodUnitID = 1,
            //    ProposedStartDate = Convert.ToDateTime("2018 - 07 - 21"),
            //    ProposedEndDate = Convert.ToDateTime("2018 - 07 - 25"),
            //    AssignmentStatusID = 1,
            //    AssignmentTypeID = 1,
            //    PracticeID = 1,
            //    AddedUser = "Lali"

            //};
            AssignmentDAO ass = new AssignmentDAO();
            await ass.AddAssignment(assignment);
        }

        static void Main(string[] args)
            {
                  
                    Program obj = new Program();
               //     var obj1= DBConfig.CreateDBInstance().Create();

                    obj.AddMember();
                   // Task<IEnumerable<Member>> IEmemberList = obj.GetAll();
                  

            }
         }   
    }

