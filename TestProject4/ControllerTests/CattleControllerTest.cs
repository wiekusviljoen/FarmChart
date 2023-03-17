using Farm.Controllers;
using Farm.Models;
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
            // Arrange  

            CattleController undertest = new CattleController();

            // Act 

            var result = undertest.Create() as ViewResult;

            // Assert

            Assert.AreEqual("Create", result.ViewName);
        }

        //[TestMethod]
        //public void TestMethod()
        //{
        //    // Arrange

        //    CattleController undertest = new CattleController();
           
            
        //    Cattle cattle = new Cattle();
        //    cattle.Breed = "Bonsmara";


        //    // Act 

        //    var result = new ViewResult();

        //    //Assert

        //    Assert.AreEqual("Index", result.ViewName);
        //}
    }
}
