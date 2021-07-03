using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApi.Models
{
    public class PrescriptionMedicament
    {
        [Key]
        public int IdMedicament { get; set; }

        [Key]
        public int IdPrescription { get; set; }

        public int? Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }

        [ForeignKey(nameof(IdMedicament))]
        public virtual Medicament Medicament { get; set; }

        [ForeignKey(nameof(IdPrescription))]
        public virtual Prescription Prescription { get; set; }
    }
}
