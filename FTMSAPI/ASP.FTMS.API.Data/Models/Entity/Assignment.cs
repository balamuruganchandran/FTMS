using System;
namespace ASP.FTMS.API.Data.Models.Entity
{
   public class Assignment
    {

        public string AssignmentID { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public int MemberID { get; set; }
        public byte ProjectID { get; set; }
        public byte ProposedUnit { get; set; }
        public byte PeriodUnitID { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public DateTime ProposedEndDate { get; set; }
        public byte AssignmentStatusID { get; set; }
        public byte AssignmentTypeID { get; set; }
        public byte PracticeID{ get; set; }
        public string AddedUser { get; set; }
        public string ModifiedUser { get; set; }
        public bool Active { get; set; }

    }
}
