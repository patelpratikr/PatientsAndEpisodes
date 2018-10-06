using System;
namespace RestApi.Interfaces
{
    public interface IPatientsController
    {
        RestApi.Models.Patient Get(int patientId);
    }
}
