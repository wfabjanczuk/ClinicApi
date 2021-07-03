namespace ClinicApi.Models.DTOs.Doctors.Delete.Response
{
    public class DeleteDoctorResult
    {
        public bool DoctorFound { get; set; }
        public bool DoctorDeleted { get; set; }
        public string Message { get; set; }
    }
}
