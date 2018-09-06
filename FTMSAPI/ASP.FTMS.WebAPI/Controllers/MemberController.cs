using System.Web.Http;
using ASP.FTMS.API.Data.DAO;
using ASP.FTMS.WebAPI.Logic;
using ASP.FTMS.WebAPI.Models.DTO;

namespace ASP.FTMS.WebAPI.Controllers
{
    public class MemberController : ApiController
    {
        MemberDAO memberDAO = new MemberDAO();

        MemberLogic memberLogic = new MemberLogic();

        public string Test()
        {
            MemberDTO member = new MemberDTO()
            {
                ACEID = "ACE0008",
                ADUserName = "Mukesh",
                FirstName = "Mukesh",
                LastName = "Kumar",
                EmailId = "Mukesh.kumar@aspiresys.com",
                Password = "mugi7",
                PhoneNumber = "9876545214",
                BatchID = 2,
                BatchName="hjg",
                PracticeID = 1,
                PracticeName="jhg",
                RoleID = 2,
                RoleName="hgfgh",
                AddedUser = "Mukesh",
            };
            memberLogic.AddMember(member);
            return "wshw";
        }

    }
}
