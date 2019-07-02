using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GhostWebserver;
using GhostWebserver.Controllers;

namespace GhostWebserver.Tests.Controllers
{
    [TestClass]
    public class GhostControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Disponer
            GhostController controller = new GhostController();
            string letter = "a";

            // Actuar
            string result = controller.Get(letter);

            // Declarar
            Assert.IsNotNull(result);
            
        }

       
        [TestMethod]
        public void Post()
        {
            // Disponer
            GhostController controller = new GhostController();

            // Actuar
            controller.Post("value");

            // Declarar
        }


        [TestMethod]
        public void Delete()
        {
            // Disponer
            GhostController controller = new GhostController();

            // Actuar
            controller.Delete();

            // Declarar
        }
    }
}
