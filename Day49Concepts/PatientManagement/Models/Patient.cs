using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string DateOfBirth {  get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Contact number Length Should 10 numbers")]
        public string ContactNumber { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Email {  get; set; }
        public string Address { get; set; }
        public string MedicalComments { get; set; }

        [Required]
        public bool AnyMedicationTaking {  get; set; }
        public string CreatedDate {  get; set; }
        public string UpdatedDate { get; set;}
    }
}
