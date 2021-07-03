using Microsoft.AspNetCore.Mvc;
using ClinicApi.Services;
using DTOs = ClinicApi.Models.DTOs.Doctors;
using GetResponseDTOs = ClinicApi.Models.DTOs.Doctors.Get.Response;
using CreateResponseDTOs = ClinicApi.Models.DTOs.Doctors.Create.Response;
using PutResponseDTOs = ClinicApi.Models.DTOs.Doctors.Put.Response;
using DeleteDoctorDTOs = ClinicApi.Models.DTOs.Doctors.Delete.Response;

namespace ClinicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorService.GetDoctors());
        }

        [HttpGet("{idDoctor}")]
        public IActionResult GetDoctor(int idDoctor)
        {
            GetResponseDTOs.GetDoctorResult result = _doctorService.GetDoctor(idDoctor);

            return result.DoctorFound
                ? Ok(result.Doctor)
                : NotFound(result.Message);
        }

        [HttpPost]
        public IActionResult CreateDoctor(DTOs.DoctorEditable createDoctorDto)
        {
            CreateResponseDTOs.CreateDoctorResult result = _doctorService.CreateDoctor(createDoctorDto);

            return result.DoctorCreated
                ? StatusCode(201, result.Doctor)
                : BadRequest(result.Message);
        }

        [HttpPut("{idDoctor}")]
        public IActionResult UpdateDoctor(int idDoctor, DTOs.DoctorEditable updateDoctorDto)
        {
            PutResponseDTOs.PutDoctorResult result = _doctorService.UpdateDoctor(idDoctor, updateDoctorDto);

            if (result.DoctorFound == false)
            {
                return NotFound(result.Message);
            }

            return result.DoctorUpdated
                ? Ok(result.Doctor)
                : BadRequest(result.Message);
        }

        [HttpDelete("{idDoctor}")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            DeleteDoctorDTOs.DeleteDoctorResult result = _doctorService.DeleteDoctor(idDoctor);

            if (result.DoctorFound == false)
            {
                return NotFound(result.Message);
            }

            return result.DoctorDeleted
                ? Ok()
                : BadRequest(result.Message);
        }
    }
}
