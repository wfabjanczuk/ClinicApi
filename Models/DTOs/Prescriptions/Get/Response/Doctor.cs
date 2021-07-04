namespace ClinicApi.Models.DTOs.Prescriptions.Get.Response
{
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(Models.Doctor doctor)
        {
            IdDoctor = doctor.IdDoctor;
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            Email = doctor.Email;
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
