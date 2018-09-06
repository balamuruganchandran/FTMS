using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.FTMS.API.Data.DAO.Interface;
using ASP.FTMS.API.Data.Models.Entity;
using System.Threading.Tasks;
using ASP.FTMS.API.Data.DAO;

namespace ASP.FTMS.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberDAO memberObj;
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public ActionResult Test()
        //{
        //    Member member = new Member()
        //    {
        //        ACEID = "ACE0000",
        //        ADUserName = "Raj",
        //        FirstName = "Raj",
        //        LastName = "Kumar",
        //        EmailId = "Raj.kumar@aspiresys.com",
        //        Password = "raj00",
        //        PhoneNumber = "9876543214",
        //        BatchID = 2,
        //        PracticeID = 1,
        //        RoleID = 2,
        //        AddedUser = "Raj",
        //    };

        //    Task<int> count = memberObj.AddMember(member);
        //    if (count.Equals(0))
        //        ViewBag.Message = "Success";
        //    else
        //        ViewBag.Message = "Failure";

        //    return View();
            
        }
    }

