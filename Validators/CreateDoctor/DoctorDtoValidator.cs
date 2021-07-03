using System.Collections.Generic;

namespace ClinicApi.Validators.CreateDoctor
{
    public class DoctorDtoValidator
    {
        public static bool IsValid(Models.DTOs.CreateDoctor.DoctorDto doctorDto)
        {
            bool areStringPropertiesNonEmpty = new List<string>()
            {
                doctorDto.FirstName,
                doctorDto.LastName,
                doctorDto.Email
            }.TrueForAll(s => s != null && !string.IsNullOrEmpty(s.Trim()) && s.Length <= 100);

            return areStringPropertiesNonEmpty;
        }
    }
}
