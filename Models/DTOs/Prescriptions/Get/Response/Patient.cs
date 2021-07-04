using System;

namespace ClinicApi.Models.DTOs.Prescriptions.Get.Response
{
    public class Patient
    {
        public Patient()
        {
        }

        public Patient(Models.Patient patient)
        {
            IdPatient = patient.IdPatient;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Birthdate = patient.Birthdate;
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
