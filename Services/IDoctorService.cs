using System.Collections.Generic;
using DTOs = ClinicApi.Models.DTOs.Doctors;
using GetResponseDTOs = ClinicApi.Models.DTOs.Doctors.Get.Response;
using CreateResponseDTOs = ClinicApi.Models.DTOs.Doctors.Create.Response;
using PutResponseDTOs = ClinicApi.Models.DTOs.Doctors.Put.Response;
using DeleteResponseDTOs = ClinicApi.Models.DTOs.Doctors.Delete.Response;

namespace ClinicApi.Services
{
    public interface IDoctorService
    {
        public List<DTOs.DoctorViewable> GetDoctors();
        public GetResponseDTOs.GetDoctorResult GetDoctor(int idDoctor);
        public CreateResponseDTOs.CreateDoctorResult CreateDoctor(DTOs.DoctorEditable createDoctorDto);
        public PutResponseDTOs.PutDoctorResult UpdateDoctor(int idDoctor, DTOs.DoctorEditable updateDoctorDto);
        public DeleteResponseDTOs.DeleteDoctorResult DeleteDoctor(int idDoctor);
    }
}
