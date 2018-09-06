using ASP.FTMS.WebAPI.Logic;
using ASP.FTMS.WebAPI.Logic.Interface;
using ASP.FTMS.WebAPI.Models.DTO;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASP.FTMS.WebAPI.Controllers
{
    public class AssignmentAllocationController : ApiController
    {
        IAssignmentAllocationLogic assignmentAllocationLogic;
        public AssignmentAllocationController()
        {
            this.assignmentAllocationLogic = new AssignmentAllocationLogic();
        }

        [HttpPost]
        [Route("api/Assignment/AllocateAssignment")]
        public Task<int> AllocateAssignment(AssignmentAllocationDTO assignmentAllocationDTO)
        {
            return assignmentAllocationLogic.AllocateAssignment(assignmentAllocationDTO);
        }

        [HttpPut]
        [Route("api/Assignment/ModifyAssignmentAllocation")]
        public Task<int> ModifyAssignment(AssignmentAllocationDTO assignmentAllocationDTO)
        {
            return assignmentAllocationLogic.ModifyAssignmentAllocation(assignmentAllocationDTO);
        }
    }
}
