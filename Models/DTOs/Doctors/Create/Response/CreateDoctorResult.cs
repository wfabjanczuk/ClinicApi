namespace ClinicApi.Models.DTOs.Doctors.Create.Response
{
    public class CreateDoctorResult
    {
        public bool DoctorCreated { get; set; }
        public string Message { get; set; }
        public DoctorViewable Doctor { get; set; }
    }
}
