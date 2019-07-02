using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GhostGameDomain;

namespace GhostWebserver.Tests.GhostGameDomain
{
    /// <summary>
    /// Descripción resumida de ComputerGhostPlayerTest
    /// </summary>
    [TestClass]
    public class ComputerGhostPlayerTest
    {
        GhostDictionary dictionary;

        public ComputerGhostPlayerTest()
        {

            /* Sample of MOCK
            // Creamos el mock sobre nuestra interfaz
            var mock = new Mock<IFoo>();

            // Definimos el comportamiento del método GetCount y su resultado
            mock.Setup(m => m.GetCount()).Returns(1);

            // Creamos una instancia del objeto mockeado y la testeamos
            Assert.AreEqual(1, mock.Object.GetCount());
            */

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestPlayGetForcedWin()
        {
            GhostPlayer player = new ComputerGhostPlayer(dictionary);

        }
        [TestMethod]
        public void TestPlayNotGetForcedWin()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
        [TestMethod]
        public void TestPlayGetLongestdWord()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
        [TestMethod]
        public void TestPlayNotGetLongestdWord()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }


    }
}
