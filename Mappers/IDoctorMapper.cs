using System.Collections.Generic;

namespace ClinicApi.Mappers
{
    public interface IDoctorMapper
    {
        public List<Models.DTOs.GetDoctors.DoctorDto> GetDoctors();
        public Models.DTOs.GetDoctors.DoctorDto GetDoctor(int idDoctor);
        public Models.DTOs.CreateDoctor.DoctorCreationResult CreateDoctor(Models.DTOs.CreateDoctor.DoctorDto createDoctorDto);
        public Models.DTOs.DeleteDoctor.DoctorDeletionResult DeleteDoctor(int idDoctor);
    }
}
