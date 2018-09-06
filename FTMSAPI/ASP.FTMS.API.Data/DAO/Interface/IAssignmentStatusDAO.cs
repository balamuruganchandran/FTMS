using ASP.FTMS.API.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO.Interface
{
   public interface IAssignmentStatusDAO
    {
        Task<AssignmentStatus> GetAssignmentStatusByAssignmentStatusId(int assignmentStatusID);
        Task<IEnumerable<AssignmentStatus>> GetAllAssignmentStatus();


    }
}
