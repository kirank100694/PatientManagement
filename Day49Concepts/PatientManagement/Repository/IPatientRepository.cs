using Microsoft.AspNetCore.JsonPatch;
using PatientManagement.Models;

namespace PatientManagement.Repository
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatientAsync();
        Task<Patient> GetPatientsByIdAsync(int patientId);
        Task<int> AddPetientAsync(Patient patient);
        Task UpdatePatientAsync(int petinetId, Patient petient);
        Task UpdatePatientPatchAsync(int patientId, JsonPatchDocument patient);
    }
}