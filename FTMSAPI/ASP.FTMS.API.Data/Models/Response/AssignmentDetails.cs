using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.Models.Response
{
   public class AssignmentDetails
    {
        public int AssignmentID { get;  set; }
        public string Title { get; set; }
        public string Description { get; set; }           
        public string PeriodUnitName { get; set; }
        public byte ProposedUnit { get; set; }
       
        public string PeriodName { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public DateTime ProposedEndDate { get; set; }
      
        public string AssignmentStatus { get; set; }
       
       
        public string AssignmentTypeName { get; set; }
       
        public string PracticeName { get; set; }
        public string AddedUser { get; set; }

    }
}
