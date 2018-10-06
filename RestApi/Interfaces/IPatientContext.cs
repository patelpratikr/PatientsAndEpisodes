using RestApi.Models;
using System;
namespace RestApi.Interfaces
{
    public interface IPatientContext
    {
        System.Data.Entity.IDbSet<Episode> Episodes { get; set; }
        System.Data.Entity.IDbSet<Patient> Patients { get; set; }
    }
}
