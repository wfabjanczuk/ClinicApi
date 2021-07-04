using System.Collections.Generic;
using GetResponseDTOs = ClinicApi.Models.DTOs.Prescriptions.Get.Response;

namespace ClinicApi.Services
{
    public interface IPrescriptionService
    {
        public List<GetResponseDTOs.Prescription> GetPrescriptions();
        public GetResponseDTOs.GetPrescriptionResult GetPrescription(int idPrescription);
    }
}
