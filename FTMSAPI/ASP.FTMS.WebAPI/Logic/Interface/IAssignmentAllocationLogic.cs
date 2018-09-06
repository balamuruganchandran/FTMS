using ASP.FTMS.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASP.FTMS.WebAPI.Logic.Interface
{
   public interface IAssignmentAllocationLogic
    {
        Task<int> AllocateAssignment(AssignmentAllocationDTO assigmentAllocationDTO);
        Task<AssignmentAllocationDTO> GetAssignmentAllocationByAssignmentAllocationId(int assignmentAllocationID);

        Task<IEnumerable<AssignmentAllocationDTO>> GetAllAssignmentAllocation();

        // Task<int> DeactivateAssigment(int assignmentID,string userName);
        Task<int> ModifyAssignmentAllocation(AssignmentAllocationDTO assigmentAllocationDTO);



    }
}