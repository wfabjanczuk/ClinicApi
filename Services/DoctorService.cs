using ClinicApi.Models;
using ClinicApi.Providers;
using System.Collections.Generic;
using System.Linq;
using DTOs = ClinicApi.Models.DTOs.Doctors;
using GetResponseDTOs = ClinicApi.Models.DTOs.Doctors.Get.Response;
using CreateResponseDTOs = ClinicApi.Models.DTOs.Doctors.Create.Response;
using PutResponseDTOs = ClinicApi.Models.DTOs.Doctors.Put.Response;
using DeleteResponseDTOs = ClinicApi.Models.DTOs.Doctors.Delete.Response;

namespace ClinicApi.Services
{
    public class DoctorService : Service, IDoctorService
    {
        public DoctorService(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<DTOs.DoctorViewable> GetDoctors()
        {
            return DbContext.Doctors
                .Select(d => new DTOs.DoctorViewable(d))
                .ToList();
        }

        public GetResponseDTOs.GetDoctorResult GetDoctor(int idDoctor)
        {
            DTOs.DoctorViewable doctorDto = DbContext.Doctors
                .Where(d => d.IdDoctor == idDoctor)
                .Select(d => new DTOs.DoctorViewable(d))
                .SingleOrDefault();

            bool doctorFound = doctorDto != null;

            return new GetResponseDTOs.GetDoctorResult
            {
                DoctorFound = doctorFound,
                Message = doctorFound ? null : "Doctor not found",
                Doctor = doctorDto
            };
        }

        public CreateResponseDTOs.CreateDoctorResult CreateDoctor(DTOs.DoctorEditable createDoctorDto)
        {
            if (!Validators.Doctors.DoctorDtoValidator.IsValid(createDoctorDto))
            {
                return new CreateResponseDTOs.CreateDoctorResult
                {
                    DoctorCreated = false,
                    Message = "Invalid Doctor's data"
                };
            }

            Doctor doctor = DbContext.Doctors
                .SingleOrDefault(d => d.Email.Equals(createDoctorDto.Email.Trim().ToLower()));

            if (doctor != null)
            {
                return new CreateResponseDTOs.CreateDoctorResult
                {
                    DoctorCreated = false,
                    Message = "Doctor's email already exist"
                };
            }

            doctor = new Doctor
            {
                FirstName = createDoctorDto.FirstName,
                LastName = createDoctorDto.LastName,
                Email = createDoctorDto.Email.Trim().ToLower()
            };

            DbContext.Add(doctor);
            DbContext.SaveChanges();

            return new CreateResponseDTOs.CreateDoctorResult
            {
                DoctorCreated = true,
                Doctor = new DTOs.DoctorViewable(doctor)
            };
        }

        public PutResponseDTOs.PutDoctorResult UpdateDoctor(int idDoctor, DTOs.DoctorEditable updateDoctorDto)
        {
            if (!Validators.Doctors.DoctorDtoValidator.IsValid(updateDoctorDto))
            {
                return new PutResponseDTOs.PutDoctorResult
                {
                    DoctorUpdated = false,
                    Message = "Invalid Doctor's data"
                };
            }

            Doctor doctor = DbContext.Doctors
                .SingleOrDefault(d => d.IdDoctor == idDoctor);

            if (doctor == null)
            {
                return new PutResponseDTOs.PutDoctorResult
                {
                    DoctorFound = false,
                    DoctorUpdated = false,
                    Message = "Doctor not found"
                };
            }

            Doctor doctorWithDuplicateEmail = DbContext.Doctors
                .SingleOrDefault(d => d.Email.Equals(updateDoctorDto.Email.Trim().ToLower())
                                      && d.IdDoctor != idDoctor);

            if (doctorWithDuplicateEmail != null)
            {
                return new PutResponseDTOs.PutDoctorResult
                {
                    DoctorFound = true,
                    DoctorUpdated = false,
                    Message = "Doctor's email already exist"
                };
            }

            doctor.Email = updateDoctorDto.Email;
            doctor.FirstName = updateDoctorDto.FirstName;
            doctor.LastName = updateDoctorDto.LastName;

            DbContext.SaveChanges();

            return new PutResponseDTOs.PutDoctorResult
            {
                DoctorUpdated = true,
                Doctor = new DTOs.DoctorViewable(doctor)
            };
        }

        public DeleteResponseDTOs.DeleteDoctorResult DeleteDoctor(int idDoctor)
        {
            Doctor doctor = DbContext.Doctors
                .SingleOrDefault(d => d.IdDoctor == idDoctor);

            if (doctor == null)
            {
                return new DeleteResponseDTOs.DeleteDoctorResult
                {
                    DoctorFound = false,
                    DoctorDeleted = false,
                    Message = "Doctor not found"
                };
            }

            DbContext.Remove(doctor);
            DbContext.SaveChanges();

            return new DeleteResponseDTOs.DeleteDoctorResult
            {
                DoctorFound = true,
                DoctorDeleted = true
            };
        }
    }
}
