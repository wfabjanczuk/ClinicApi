using System.Collections.Generic;
using ClinicApi.Models.DTOs.Doctors;

namespace ClinicApi.Validators.Doctors
{
    public class DoctorDtoValidator
    {
        public static bool IsValid(DoctorEditable doctorDto)
        {
            bool areStringPropertiesValid = new List<string>()
            {
                doctorDto.FirstName,
                doctorDto.LastName,
                doctorDto.Email
            }.TrueForAll(s => s != null && !string.IsNullOrEmpty(s.Trim()) && s.Length <= 100);

            return areStringPropertiesValid;
        }
    }
}
