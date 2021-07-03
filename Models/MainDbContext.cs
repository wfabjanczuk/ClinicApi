using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ClinicApi.Models
{
    public class MainDbContext : DbContext
    {
        protected readonly string DbConnectionString;

        public MainDbContext(IConfiguration configuration) : base()
        {
            DbConnectionString = configuration["DbConnectionString"];
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(Console.Write)
                    .UseSqlServer(DbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.ToTable("Doctor");

                opt.HasKey(e => e.IdDoctor);
                opt.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Email).IsRequired().HasMaxLength(100);

                opt.HasData(
                    new Doctor()
                    {
                        IdDoctor = 1,
                        FirstName = "Adam",
                        LastName = "Alastname",
                        Email = "adam@gmail.com"
                    },
                    new Doctor()
                    {
                        IdDoctor = 2,
                        FirstName = "Barbara",
                        LastName = "Blastname",
                        Email = "barbara@gmail.com"
                    },
                    new Doctor()
                    {
                        IdDoctor = 3,
                        FirstName = "Celina",
                        LastName = "Clastname",
                        Email = "celina@gmail.com"
                    }
                );
            });

            modelBuilder.Entity<Medicament>(opt =>
            {
                opt.ToTable("Medicament");

                opt.HasKey(e => e.IdMedicament);
                opt.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

                opt.Property(e => e.Name).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Description).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Type).IsRequired().HasMaxLength(100);

                opt.HasData(
                    new Medicament()
                    {
                        IdMedicament = 1,
                        Name = "Apap",
                        Description = "Bez recepty",
                        Type = "Przeciwbólowy"
                    },
                    new Medicament()
                    {
                        IdMedicament = 2,
                        Name = "Paracetamol",
                        Description = "Bez recepty",
                        Type = "Przeciwbólowy"
                    },
                    new Medicament()
                    {
                        IdMedicament = 3,
                        Name = "Ibuprofen",
                        Description = "Bez recepty",
                        Type = "Przeciwbólowy"
                    },
                    new Medicament()
                    {
                        IdMedicament = 4,
                        Name = "Rutinoscorbin",
                        Description = "Bez recepty",
                        Type = "Witamina C"
                    },
                    new Medicament()
                    {
                        IdMedicament = 5,
                        Name = "Allegra",
                        Description = "Bez recepty",
                        Type = "Alergia"
                    }
                );
            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.ToTable("Patient");

                opt.HasKey(e => e.IdPatient);
                opt.Property(e => e.IdPatient).ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                opt.Property(e => e.Birthdate).HasColumnType("datetime");

                opt.HasData(
                    new Patient()
                    {
                        IdPatient = 1,
                        FirstName = "Diana",
                        LastName = "Dlastname",
                        Birthdate = DateTime.Now
                    },
                    new Patient()
                    {
                        IdPatient = 2,
                        FirstName = "Edward",
                        LastName = "Elastname",
                        Birthdate = DateTime.Now
                    },
                    new Patient()
                    {
                        IdPatient = 3,
                        FirstName = "Frank",
                        LastName = "Flastname",
                        Birthdate = DateTime.Now
                    },
                    new Patient()
                    {
                        IdPatient = 4,
                        FirstName = "Gregory",
                        LastName = "Glastname",
                        Birthdate = DateTime.Now
                    },
                    new Patient()
                    {
                        IdPatient = 5,
                        FirstName = "Henry",
                        LastName = "Hlastname",
                        Birthdate = DateTime.Now
                    }
                );
            });

            modelBuilder.Entity<Prescription>(opt =>
            {
                opt.ToTable("Prescription");

                opt.HasKey(e => e.IdPrescription);
                opt.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

                opt.Property(e => e.Date).HasColumnType("datetime");
                opt.Property(e => e.DueDate).HasColumnType("datetime");

                opt.HasOne(e => e.Doctor).WithMany(d => d.Prescriptions).HasForeignKey(p => p.IdPrescription);
                opt.HasOne(e => e.Patient).WithMany(p => p.Prescriptions).HasForeignKey(p => p.IdPrescription);

                opt.HasData(
                    new Prescription()
                    {
                        IdPrescription = 1,
                        IdDoctor = 1,
                        IdPatient = 1,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now
                    },
                    new Prescription()
                    {
                        IdPrescription = 2,
                        IdDoctor = 1,
                        IdPatient = 2,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now
                    }
                );
            });

            modelBuilder.Entity<PrescriptionMedicament>(opt =>
            {
                opt.ToTable("Prescription_Medicament");

                opt.HasKey(e => new { e.IdPrescription, e.IdMedicament });

                opt.Property(e => e.Details).IsRequired().HasMaxLength(100);

                opt.HasOne(e => e.Prescription).WithMany(p => p.PrescriptionMedicaments).HasForeignKey(pm => pm.IdPrescription);
                opt.HasOne(e => e.Medicament).WithMany(m => m.PrescriptionMedicaments).HasForeignKey(pm => pm.IdMedicament);

                opt.HasData(
                    new PrescriptionMedicament()
                    {
                        IdPrescription = 1,
                        IdMedicament = 1,
                        Details = "Some details",
                        Dose = 1
                    },
                    new PrescriptionMedicament()
                    {
                        IdPrescription = 1,
                        IdMedicament = 4,
                        Details = "Some details",
                        Dose = null
                    },
                    new PrescriptionMedicament()
                    {
                        IdPrescription = 2,
                        IdMedicament = 5,
                        Details = "Some details",
                        Dose = 2
                    }
                );
            });
        }
    }
}
