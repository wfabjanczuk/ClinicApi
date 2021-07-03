using System;
using System.Collections.Generic;

namespace ClinicApi.Models.DTOs.GetDoctors
{
    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDto Patient { get; set; }
        public List<MedicamentDto> Medicaments { get; set; }
    }
}
