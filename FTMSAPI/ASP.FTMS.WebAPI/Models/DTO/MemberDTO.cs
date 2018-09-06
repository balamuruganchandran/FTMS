
namespace ASP.FTMS.WebAPI.Models.DTO
{
    public class MemberDTO:BaseDTO
    {
        public string ACEID { get; set; }
        public string ADUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public byte BatchID { get; set; }
        public string BatchName { get; set; }
        public byte PracticeID { get; set; }
        public string PracticeName { get; set; }
        public byte RoleID { get; set; }
        public string RoleName { get; set; }
          
    }
}