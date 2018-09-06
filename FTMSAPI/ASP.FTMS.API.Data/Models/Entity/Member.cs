using System;
namespace ASP.FTMS.API.Data.Models.Entity
{
  public  class Member
    {
        public int MemberID { get; set; }
        public string ACEID { get; set; }
        public string ADUserName { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Batch Batch { get; set; }
        public Practice Practice { get; set; }
        public Roles Roles { get; set; }
        public string AddedUser { get; set; }
        public bool Active { get; set; }

    }
}
