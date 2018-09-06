using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO.Interface
{
    public interface IAssignmentDAO
    {
        Task<int> AddAssignmentAsync(Assignment assignment);
        Task<AssignmentDetails> GetAssignmentByAssignmentId(int assignmentID);
        Task<IEnumerable<AssignmentDetails>> GetAllAssignments();
        Task<int> ModifyAssignment(Assignment assignment);
        //Task<int> DeactivateAssignment(int assignmentID, string userName);
    }
}
