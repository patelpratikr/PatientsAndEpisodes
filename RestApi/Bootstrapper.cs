using System.Web.Mvc;
using Microsoft.Practices.Unity;
using RestApi.Controllers;
using RestApi.Models;
using System.Web.Http;
using Unity;
using RestApi.Interfaces;

namespace RestApi
{
  public static class Bootstrapper
  {
      public static IUnityContainer Initialize()
      {
          var container = new UnityContainer();
          container.RegisterType<IPatientsController, PatientsController>();
          container.RegisterType<IPatientContext, PatientContext>();

          return container;
      }
  }
}