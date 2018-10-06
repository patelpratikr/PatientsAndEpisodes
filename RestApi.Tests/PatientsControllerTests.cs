using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using RestApi.Interfaces;
using RestApi.Models;
using System.Net;
using System.Web.Http;

namespace RestApi.Tests
{
    [TestClass]
    public class PatientsControllerTests
    {
        IUnityContainer container;

        [TestInitialize]
        public void SetUp()
        {
            container = Bootstrapper.Initialize();

            // Override any registration of IPatientContext to Mock context for testing purpose
            container.RegisterType<IPatientContext, MockPatientContext>();
        }

        [TestMethod]
        public void Get_ByValidPatientId_ReturnsValidPatient()
        {
            // Arrange
            var patientsController = container.Resolve<IPatientsController>();
            
            // Act
            var patient = patientsController.Get(1);

            //Assert
            Assert.AreEqual<string>(patient.FirstName, "Test");            
        }

        [TestMethod]
        public void Get_ByInvalidPatientId_Returns404()
        {
            // Arrange
            var patientsController = container.Resolve<IPatientsController>();

            // Act
            Patient patient = new Patient();
            try
            {
                patient = patientsController.Get(2);
            }
            catch (HttpResponseException e)
            {
                //Assert
                Assert.AreEqual(e.Response.StatusCode, HttpStatusCode.NotFound);   
            }            
        }

        [TestCleanup]
        public void TestDissolve()
        {
            container = null;
        }
    }
}
