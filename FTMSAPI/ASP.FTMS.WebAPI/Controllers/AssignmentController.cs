using ASP.FTMS.WebAPI.Logic;
using ASP.FTMS.WebAPI.Logic.Interface;
using ASP.FTMS.WebAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASP.FTMS.WebAPI.Controllers
{
    public class AssignmentController : ApiController
    {
        IAssignmentLogic assignmentLogic;
        public AssignmentController()
        {
            this.assignmentLogic = new AssignmentLogic();
        }

        [HttpPost]
        [Route("api/Assignment/AddAssignment")]
        public Task<int> AddAssignment(AssignmentDTO assignmentDTO)
        {

            return assignmentLogic.AddAssignment(assignmentDTO);
        }

        [HttpGet]
        [Route("api/Assignment/GetAllAssignment")]
        public Task<IEnumerable<AssignmentDTO>> GetAllAssignment()
        {
            AssignmentLogic assignmentLogic = new AssignmentLogic();

            return assignmentLogic.GetAllAssignments();
        }

        [HttpGet]
        [Route("api/Assignment/GetAssignmentById")]
        public Task<AssignmentDTO> GetAssignmentById(int id)
        {

            return assignmentLogic.GetAssignmentByAssignmentId(id);
        }

        [HttpPut]
        [Route("api/Assignment/ModifyAssignment")]
        public Task<int> ModifyAssignment(AssignmentDTO assignmentDTO)
        {

            return assignmentLogic.ModifyAssignment(assignmentDTO);
        }

    }
}
