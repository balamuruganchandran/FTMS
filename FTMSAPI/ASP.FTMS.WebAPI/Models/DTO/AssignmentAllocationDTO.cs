using System;

namespace ASP.FTMS.WebAPI.Models.DTO
{
    public class AssignmentAllocationDTO:BaseDTO
    {
        public int AssignmentID { get; set; }
        public string AssignmentAllocationID { get; set; }
        public int MemberID { get; set; }
        public byte RequiredUnit { get; set; }
        public byte AllocationStatusID { get; set; }
        public byte PeriodUnitID { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public DateTime ProposedEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
    }
}
