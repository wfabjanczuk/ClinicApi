namespace ClinicApi.Models.DTOs.Doctors.Put.Response
{
    public class PutDoctorResult
    {
        public bool? DoctorFound { get; set; }
        public bool DoctorUpdated { get; set; }
        public string Message { get; set; }
        public DoctorViewable Doctor { get; set; }
    }
}
