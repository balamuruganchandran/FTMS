using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.Models.Entity
{
   public class AssignmentAllocation
    {
        public int AssignmentID { get; set; }
        public string AssignmentAllocationID { get; set; }
        public int MemberID { get; set; }

        public byte RequiredUnit { get; set; }

       
        public byte AllocationStatusID { get; set;}
        public byte PeriodUnitID { get; set; }

        public DateTime ProposedStartDate { get; set; }

        public DateTime ProposedEndDate { get; set; }

        public DateTime ActualStartDate { get; set; }

        public DateTime ActualEndDate { get; set; }

        public string AddedUser { get; set; }

        public string ModifiedUser { get; set; }
    }
}
