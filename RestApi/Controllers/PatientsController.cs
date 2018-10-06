using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Controllers
{
    /// <summary>
    /// Patients Controller class
    /// </summary>
    public class PatientsController : ApiController, RestApi.Interfaces.IPatientsController
    {
        // Private properties for DI
        private IPatientContext patientContext;

        public PatientsController(IPatientContext patientContext)
        {
            this.patientContext = patientContext;
        }

        public PatientsController()
        {

        }

        [HttpGet]
        public Patient Get(int patientId)
        {
            var patientsAndEpisodes =
                from p in patientContext.Patients
                join e in patientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}