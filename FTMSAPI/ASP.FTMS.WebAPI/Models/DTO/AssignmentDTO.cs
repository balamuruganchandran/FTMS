using System;

namespace ASP.FTMS.WebAPI.Models.DTO
{
    public class AssignmentDTO: BaseDTO
    {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MemberID { get; set; }
        public byte ProjectID { get; set; }
        public string PeriodUnitName { get; set; }
        public byte ProposedUnit { get; set; }      
        public byte PeriodUnitID { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public DateTime ProposedEndDate { get; set; }
        public byte AssignmentStatusID { get; set; }
        public string AssignmentStatus { get; set; }
        public byte AssignmentTypeID { get; set; }
        public string AssignmentTypeName { get; set; }
        public byte PracticeID { get; set; }
        public string PracticeName { get; set; }
     

    }
}