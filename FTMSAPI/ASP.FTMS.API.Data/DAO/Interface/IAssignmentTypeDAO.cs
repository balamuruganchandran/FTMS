using ASP.FTMS.API.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO.Interface
{
    interface IAssignmentTypeDAO
    {
        Task<AssignmentType> GetAssignmentTypeByAssignmentTypeId(int assignmentTypeID);
        Task<IEnumerable<AssignmentType>> GetAllAssignmentType();

    }
}
