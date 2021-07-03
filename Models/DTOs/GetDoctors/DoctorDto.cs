using System.Collections.Generic;

namespace ClinicApi.Models.DTOs.GetDoctors
{
    public class DoctorDto
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual List<PrescriptionDto> Prescriptions { get; set; }
    }
}
