using ClinicApi.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GetResponseDTOs = ClinicApi.Models.DTOs.Prescriptions.Get.Response;

namespace ClinicApi.Services
{
    public class PrescriptionService : Service, IPrescriptionService
    {
        public PrescriptionService(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<GetResponseDTOs.Prescription> GetPrescriptions()
        {
            return GetPrescriptionsQuery()
                .Select(p => new GetResponseDTOs.Prescription(p))
                .ToList();
        }

        public GetResponseDTOs.GetPrescriptionResult GetPrescription(int idPrescription)
        {
            GetResponseDTOs.Prescription prescriptionDto = GetPrescriptionsQuery()
                .Where(p => p.IdPrescription == idPrescription)
                .Select(p => new GetResponseDTOs.Prescription(p))
                .SingleOrDefault();

            bool prescriptionFound = prescriptionDto != null;

            return new GetResponseDTOs.GetPrescriptionResult
            {
                PrescriptionFound = prescriptionFound,
                Message = prescriptionFound ? null : "Prescription not found",
                Prescription = prescriptionDto
            };
        }

        public IQueryable<Models.Prescription> GetPrescriptionsQuery()
        {
            return DbContext.Prescriptions
                .Include("Doctor")
                .Include("Patient")
                .Include("PrescriptionMedicaments.Medicament");
        }
    }
}
