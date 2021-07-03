using ClinicApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorMapper DoctorMapper;

        public DoctorsController(IDoctorMapper doctorMapper)
        {
            DoctorMapper = doctorMapper;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(DoctorMapper.GetDoctors());
        }

        [HttpGet("{idDoctor}")]
        public IActionResult GetDoctor(int idDoctor)
        {
            Models.DTOs.GetDoctors.DoctorDto doctor = DoctorMapper.GetDoctor(idDoctor);

            return doctor == null
                ? NotFound(null)
                : Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor(Models.DTOs.CreateDoctor.DoctorDto createDoctorDto)
        {
            return Ok(DoctorMapper.CreateDoctor(createDoctorDto));
        }

        [HttpDelete("{idDoctor}")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            Models.DTOs.DeleteDoctor.DoctorDeletionResult result = DoctorMapper.DeleteDoctor(idDoctor);

            return result.DoctorFound
                ? Ok(result.Message)
                : NotFound(result.Message);
        }
    }
}
