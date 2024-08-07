using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Data;
using PatientManagement.Models;
using PatientManagement.Repository;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository) 
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatient()
        {
            var patients = await _patientRepository.GetAllPatientAsync();
            if (patients == null)
            {
                return BadRequest("Please Add Patient");
            }

            return Ok(patients);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int Id)
        {
            var patients = await _patientRepository.GetPatientsByIdAsync(Id);
            if (patients == null)
            {
                return NotFound();
            }

            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            var patients = await _patientRepository.AddPetientAsync(patient);

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id, controller = "patient" }, patient);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePatients([FromBody] Patient patient, [FromRoute] int Id)
        {
            await _patientRepository.UpdatePatientAsync(Id, patient);
            if(patient == null)
            {
                return BadRequest("Please provide Patient details");
            }

            return Ok(true);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdatePatientPatch([FromBody] JsonPatchDocument patient, [FromRoute] int Id)
        {
            await _patientRepository.UpdatePatientPatchAsync(Id, patient);
            if(patient == null)
            {
                return BadRequest("Remove is not allowed");
            }

            return Ok(true);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int Id)
        {
            await _patientRepository.DeletePatientAsync(Id);
            if (Id != 0)
            {
                return BadRequest("Please provide valid result");
            }

            return Ok(true);

            
        }
    }
}
