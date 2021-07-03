namespace ClinicApi.Models.DTOs.Doctors
{
    public class DoctorEditable
    {
        public DoctorEditable()
        {
        }

        public DoctorEditable(Doctor doctor)
        {
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            Email = doctor.Email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
