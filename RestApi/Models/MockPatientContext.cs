using RestApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class MockPatientContext : IPatientContext
    {
        public MockPatientContext()
        {
            // Setup patients
            Patients = new InMemoryDbSet<Patient>();

            var patient = new Patient()
            {
                FirstName = "Test",
                LastName = "Test",
                PatientId = 1,
                DateOfBirth = new DateTime(1983, 1, 1)                
            };

            Patients.Add(patient);

            // Setup episodes
            Episodes = new InMemoryDbSet<Episode>();
            var episode = new Episode()
            {
                PatientId = 1,
                EpisodeId = 1,
                Diagnosis = "Fever",
                AdmissionDate = new DateTime(2018, 1, 1),
                DischargeDate = new DateTime(2018, 2, 2)
            };

            Episodes.Add(episode);            
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }
    }
}