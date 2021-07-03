namespace ClinicApi.Models.DTOs.Doctors.Get.Response
{
    public class GetDoctorResult
    {
        public bool DoctorFound { get; set; }
        public string Message { get; set; }
        public DoctorViewable Doctor { get; set; }
    }
}
