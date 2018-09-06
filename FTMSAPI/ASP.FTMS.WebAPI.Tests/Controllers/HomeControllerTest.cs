using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP.FTMS.WebAPI;
using ASP.FTMS.WebAPI.Controllers;
namespace ASP.FTMS.WebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
