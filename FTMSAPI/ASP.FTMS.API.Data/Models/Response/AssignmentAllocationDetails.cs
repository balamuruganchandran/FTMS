using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.Models.Response
{
    public class AssignmentAllocationDetails
    {
        public int AssignmentAllocationID { get; set; }
        public int AssignmentID { get; set; }
        public byte RequiredUnit { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public DateTime ProposedEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int MemberID { get; set; }
        public string PeriodName { get; set; }
        public string AllocationStatus { get; set; }

    }
}
