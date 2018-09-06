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
    public class AssignmentAllocationLogic:IAssignmentAllocationLogic
    {
        private IAssignmentAllocationDAO assignmentAllocationDAO;

        public AssignmentAllocationLogic()
        {
            this.assignmentAllocationDAO = new AssignmentAllocationDAO();
        }
        public Task<int> AllocateAssignment(AssignmentAllocationDTO assignmentAllocationDTO)
        {
            AssignmentAllocation assignmentAllocation = Mapper.Map<AssignmentAllocationDTO, AssignmentAllocation>(assignmentAllocationDTO);
            return assignmentAllocationDAO.AllocateAssignment(assignmentAllocation);
        }
        public Task<int> ModifyAssignmentAllocation(AssignmentAllocationDTO assignmentAllocationDTO)
        {
            AssignmentAllocation assignmentAllocation = Mapper.Map<AssignmentAllocationDTO, AssignmentAllocation>(assignmentAllocationDTO);
            return assignmentAllocationDAO.ModifyAssignmentAllocation(assignmentAllocation);
        }
        public async Task<AssignmentAllocationDTO> GetAssignmentAllocationByAssignmentAllocationId(int assignmentAllocationId)
        {
            AssignmentAllocationDetails assignmentAllocationDetails = await assignmentAllocationDAO.GetAssignmentAllocationByAllocationId(assignmentAllocationId);    
            return Mapper.Map<AssignmentAllocationDetails, AssignmentAllocationDTO>(assignmentAllocationDetails);
        }
        public async Task<IEnumerable<AssignmentAllocationDTO>> GetAllAssignmentAllocation()
        {
            IEnumerable<AssignmentAllocationDetails> assignmentAllocationDetails = await assignmentAllocationDAO.GetAllAssignmentAllocation();
            return Mapper.Map<IEnumerable<AssignmentAllocationDetails>, IEnumerable<AssignmentAllocationDTO>>(assignmentAllocationDetails);             
        }
    }
}