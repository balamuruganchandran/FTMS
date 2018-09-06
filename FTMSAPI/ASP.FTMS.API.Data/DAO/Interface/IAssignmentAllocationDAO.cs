using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO.Interface
{
    public interface IAssignmentAllocationDAO
    {
        Task<int> AllocateAssignment(AssignmentAllocation assignmentAllocation);
        Task<AssignmentAllocationDetails> GetAssignmentAllocationByAllocationId(int assignmentAllocationID);
        Task<IEnumerable<AssignmentAllocationDetails>> GetAllAssignmentAllocation();
        Task<int> ModifyAssignmentAllocation(AssignmentAllocation assignmentAllocation);
    }
}
