using ClinicApi.Services;
using Microsoft.AspNetCore.Mvc;
using GetResponseDTOs = ClinicApi.Models.DTOs.Prescriptions.Get.Response;

namespace ClinicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public IActionResult GetPrescriptions()
        {
            return Ok(_prescriptionService.GetPrescriptions());
        }

        [HttpGet("{idPrescription}")]
        public IActionResult GetPrescription(int idPrescription)
        {
            GetResponseDTOs.GetPrescriptionResult result = _prescriptionService.GetPrescription(idPrescription);

            return result.PrescriptionFound
                ? Ok(result.Prescription)
                : NotFound(result.Message);
        }
    }
}
