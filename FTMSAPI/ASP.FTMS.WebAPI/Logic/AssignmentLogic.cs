using ASP.FTMS.API.Data.DAO;
using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.Data.Models.Response;
using ASP.FTMS.WebAPI.Logic.Interface;
using ASP.FTMS.WebAPI.Models.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.FTMS.WebAPI.Logic
{
    public class AssignmentLogic : IAssignmentLogic
    {
       private readonly IAssignmentDAO assignmentDAO;
        public AssignmentLogic()
        {
            this.assignmentDAO = new AssignmentDAO();
        }     
        public Task<int> AddAssignment(AssignmentDTO assignmentDTO)
        {          
            Assignment assignment = Mapper.Map<AssignmentDTO, Assignment>(assignmentDTO);
            return assignmentDAO.AddAssignmentAsync(assignment);          
        }

        public async Task<AssignmentDTO> GetAssignmentByAssignmentId(int assignmentID)
        {
            AssignmentDetails assigmentDetails = await assignmentDAO.GetAssignmentByAssignmentId(assignmentID);
            AssignmentDTO assignmentDTO = Mapper.Map<AssignmentDetails, AssignmentDTO>(assigmentDetails);
            return assignmentDTO;

        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllAssignments()
        {
            IEnumerable<AssignmentDetails> assigmentDetails = await assignmentDAO.GetAllAssignments();
            return Mapper.Map<IEnumerable<AssignmentDetails>, IEnumerable<AssignmentDTO>>(assigmentDetails);

        }

        //public Task<int> DeactivateAssigment(int assignmentID, string userName)
        //{
           
        //    var result = assignmentDAO.DeactivateAssignment(assignmentID, userName);
        //    return result;
        //}

        public Task<int> ModifyAssignment(AssignmentDTO assignmentDTO)
        {           
            Assignment assignment = Mapper.Map<AssignmentDTO, Assignment>(assignmentDTO);
            var result= assignmentDAO.ModifyAssignment(assignment);
            return result;
        }
    }
}