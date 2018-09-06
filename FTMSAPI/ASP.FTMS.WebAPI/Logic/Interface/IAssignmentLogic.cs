using ASP.FTMS.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.WebAPI.Logic.Interface
{
    interface IAssignmentLogic
    {

        Task<int> AddAssignment(AssignmentDTO assignmentDTO);
        Task<AssignmentDTO> GetAssignmentByAssignmentId(int assignmentID);

        Task<IEnumerable<AssignmentDTO>> GetAllAssignments();

       // Task<int> DeactivateAssigment(int assignmentID,string userName);
        Task<int> ModifyAssignment(AssignmentDTO assignmentDTO);

    }
}
