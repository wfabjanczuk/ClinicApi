using ClinicApi.Models;
using ClinicApi.Providers;
using System.Collections.Generic;
using System.Linq;

namespace ClinicApi.Mappers
{
    public class DoctorMapper : Mapper, IDoctorMapper
    {
        public DoctorMapper(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<Models.DTOs.GetDoctors.DoctorDto> GetDoctors()
        {
            return GetDoctorDtos().ToList();
        }

        public Models.DTOs.GetDoctors.DoctorDto GetDoctor(int idDoctor)
        {
            return GetDoctorDtos()
                .Where(d => d.IdDoctor == idDoctor)
                .SingleOrDefault();
        }

        private IQueryable<Models.DTOs.GetDoctors.DoctorDto> GetDoctorDtos()
        {
            return DbContext.Doctors
              .Select(d => new Models.DTOs.GetDoctors.DoctorDto()
              {
                  IdDoctor = d.IdDoctor,
                  FirstName = d.FirstName,
                  LastName = d.LastName,
                  Email = d.Email,
                  Prescriptions = d.Prescriptions.Select(p => new Models.DTOs.GetDoctors.PrescriptionDto()
                  {
                      IdPrescription = p.IdPrescription,
                      Date = p.Date,
                      DueDate = p.DueDate,
                      Patient = new Models.DTOs.GetDoctors.PatientDto()
                      {
                          IdPatient = p.Patient.IdPatient,
                          FirstName = p.Patient.FirstName,
                          LastName = p.Patient.LastName,
                          Birthdate = p.Patient.Birthdate
                      },
                      Medicaments = p.PrescriptionMedicaments.Select(pm => new Models.DTOs.GetDoctors.MedicamentDto()
                      {
                          IdMedicament = pm.IdMedicament,
                          Name = pm.Medicament.Name,
                          Description = pm.Medicament.Description,
                          Type = pm.Medicament.Type,
                          Dose = pm.Dose,
                          Details = pm.Details
                      }).ToList()
                  }).ToList()
              });
        }

        public Models.DTOs.CreateDoctor.DoctorCreationResult CreateDoctor(Models.DTOs.CreateDoctor.DoctorDto createDoctorDto)
        {
            if (!Validators.CreateDoctor.DoctorDtoValidator.IsValid(createDoctorDto))
            {
                return new Models.DTOs.CreateDoctor.DoctorCreationResult
                {
                    Message = "Invalid Doctor's data"
                };
            }

            Doctor doctor = DbContext.Doctors
                .Where(d => d.Email.Equals(createDoctorDto.Email.Trim().ToLower()))
                .SingleOrDefault();

            if (doctor != null)
            {
                return new Models.DTOs.CreateDoctor.DoctorCreationResult
                {
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

            return new Models.DTOs.CreateDoctor.DoctorCreationResult
            {
                Message = "Doctor successfully created",
                Doctor = doctor
            };
        }

        public Models.DTOs.DeleteDoctor.DoctorDeletionResult DeleteDoctor(int idDoctor)
        {
            Doctor doctor = DbContext.Doctors
                .Where(d => d.IdDoctor == idDoctor)
                .SingleOrDefault();

            if (doctor == null)
            {
                return new Models.DTOs.DeleteDoctor.DoctorDeletionResult
                {
                    DoctorFound = false,
                    Message = "Doctor not found"
                };
            }

            DbContext.Remove(doctor);
            DbContext.SaveChanges();

            return new Models.DTOs.DeleteDoctor.DoctorDeletionResult
            {
                DoctorFound = true,
                Message = "Doctor succesfully removed"
            };
        }
    }
}
