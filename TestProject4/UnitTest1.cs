

using Farm.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject4
{
    [TestClass]
    public class HomeControllerTest
    {


        [TestMethod]
        public void Index()
        {
            //Arrange

            HomeController controller = new HomeController();

            //Act

            ViewResult result = controller.Index() as ViewResult;

            //Assert

            Assert.IsNotNull(result);
        }
    }
}