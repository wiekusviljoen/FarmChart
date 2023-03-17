using Farm.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject4.ControllerTests
{
    [TestClass]
    public class CattleControllerTest
    {

        [TestMethod]

        public void Create()
        {
            // Arrang 
            CattleController undertest = new CattleController();
            // Act
            var result = undertest.Create() as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
