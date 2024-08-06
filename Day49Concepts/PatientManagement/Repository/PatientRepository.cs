using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.Migrations;
using PatientManagement.Models;

namespace PatientManagement.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _patientContext;

        public PatientRepository(PatientContext patientContext)
        {
            _patientContext = patientContext;
        }

        public async Task<List<Patient>> GetAllPatientAsync()
        {
            var records = await _patientContext.Patients.Select(x => new Patient()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                ContactNumber = x.ContactNumber,
                Weight = x.Weight,
                Height = x.Height,
                Email = x.Email,
                Address = x.Address,
                MedicalComments = x.MedicalComments,
                AnyMedicationTaking = x.AnyMedicationTaking,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToListAsync();

            return records;
        }

        public async Task<Patient> GetPatientsByIdAsync(int patientId)
        {
            var records = await _patientContext.Patients.Where(x => x.Id == patientId).Select(x => new Patient()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                ContactNumber = x.ContactNumber,
                Weight = x.Weight,
                Height = x.Height,
                Email = x.Email,
                Address = x.Address,
                MedicalComments = x.MedicalComments,
                AnyMedicationTaking = x.AnyMedicationTaking,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<int> AddPetientAsync(Patient patient)
        {
            var records = new Patient()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                ContactNumber = patient.ContactNumber,
                Weight = patient.Weight,
                Height = patient.Height,
                Email = patient.Email,
                Address = patient.Address,
                MedicalComments = patient.MedicalComments,
                AnyMedicationTaking = patient.AnyMedicationTaking,
                CreatedDate = patient.CreatedDate,
                UpdatedDate = patient.UpdatedDate
            };

            _patientContext.Patients.Add(records);
            await _patientContext.SaveChangesAsync();

            return records.Id;
        }

        public async Task UpdatePatientAsync(int petinetId, Patient petient)
        {
            var records = new Patient()
            {
                Id = petient.Id,
                FirstName = petient.FirstName,
                LastName = petient.LastName,
                DateOfBirth = petient.DateOfBirth,
                Gender = petient.Gender,
                ContactNumber = petient.ContactNumber,
                Weight = petient.Weight,
                Height = petient.Height,
                Email = petient.Email,
                Address = petient.Address,
                MedicalComments = petient.MedicalComments,
                AnyMedicationTaking = petient.AnyMedicationTaking,
                CreatedDate = petient.CreatedDate,
                UpdatedDate = petient.UpdatedDate
            };

            _patientContext.Patients.Update(records);
            await _patientContext.SaveChangesAsync();
        }

        public async Task UpdatePatientPatchAsync(int patientId, JsonPatchDocument patient)
        {
            var record = await _patientContext.Patients.FindAsync(patientId);
            if (record != null)
            {
                patient.ApplyTo(record);
                await _patientContext.SaveChangesAsync();
            }
        }
    }
}
