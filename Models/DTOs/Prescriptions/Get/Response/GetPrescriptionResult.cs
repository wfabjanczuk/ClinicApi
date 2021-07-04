using GetDTOs = ClinicApi.Models.DTOs.Prescriptions.Get.Response;

namespace ClinicApi.Models.DTOs.Prescriptions.Get.Response
{
    public class GetPrescriptionResult
    {
        public bool PrescriptionFound { get; set; }
        public string Message { get; set; }
        public GetDTOs.Prescription Prescription { get; set; }
    }
}
