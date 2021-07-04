using System;
using System.Collections.Generic;
using System.Linq;
using GetDTOs = ClinicApi.Models.DTOs.Prescriptions.Get.Response;

namespace ClinicApi.Models.DTOs.Prescriptions.Get.Response
{
    public class Prescription
    {
        public Prescription()
        {
        }

        public Prescription(Models.Prescription prescription)
        {
            IdPrescription = prescription.IdPrescription;
            Date = prescription.Date;
            DueDate = prescription.DueDate;
            Doctor = new Doctor(prescription.Doctor);
            Patient = new Patient(prescription.Patient);
            Medicaments = prescription.PrescriptionMedicaments
                .Select(pm => new Medicament(pm))
                .ToList();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public GetDTOs.Doctor Doctor { get; set; }
        public GetDTOs.Patient Patient { get; set; }
        public List<GetDTOs.Medicament> Medicaments { get; set; }
    }
}
