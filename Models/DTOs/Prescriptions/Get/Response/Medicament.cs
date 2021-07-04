namespace ClinicApi.Models.DTOs.Prescriptions.Get.Response
{
    public class Medicament
    {
        public Medicament()
        {
        }

        public Medicament(Models.PrescriptionMedicament prescriptionMedicament)
        {
            IdMedicament = prescriptionMedicament.Medicament.IdMedicament;
            Name = prescriptionMedicament.Medicament.Name;
            Description = prescriptionMedicament.Medicament.Description;
            Type = prescriptionMedicament.Medicament.Type;
            Dose = prescriptionMedicament.Dose;
            Details = prescriptionMedicament.Details;
        }

        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}
