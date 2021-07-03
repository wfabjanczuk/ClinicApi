﻿// <auto-generated />
using System;
using ClinicApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicApi.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210703131331_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicApi.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "adam@gmail.com",
                            FirstName = "Adam",
                            LastName = "Alastname"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "barbara@gmail.com",
                            FirstName = "Barbara",
                            LastName = "Blastname"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "celina@gmail.com",
                            FirstName = "Celina",
                            LastName = "Clastname"
                        });
                });

            modelBuilder.Entity("ClinicApi.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Bez recepty",
                            Name = "Apap",
                            Type = "Przeciwbólowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Bez recepty",
                            Name = "Paracetamol",
                            Type = "Przeciwbólowy"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Bez recepty",
                            Name = "Ibuprofen",
                            Type = "Przeciwbólowy"
                        },
                        new
                        {
                            IdMedicament = 4,
                            Description = "Bez recepty",
                            Name = "Rutinoscorbin",
                            Type = "Witamina C"
                        },
                        new
                        {
                            IdMedicament = 5,
                            Description = "Bez recepty",
                            Name = "Allegra",
                            Type = "Alergia"
                        });
                });

            modelBuilder.Entity("ClinicApi.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(2021, 7, 3, 15, 13, 29, 922, DateTimeKind.Local).AddTicks(7625),
                            FirstName = "Diana",
                            LastName = "Dlastname"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(2021, 7, 3, 15, 13, 29, 924, DateTimeKind.Local).AddTicks(5707),
                            FirstName = "Edward",
                            LastName = "Elastname"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(2021, 7, 3, 15, 13, 29, 924, DateTimeKind.Local).AddTicks(5733),
                            FirstName = "Frank",
                            LastName = "Flastname"
                        },
                        new
                        {
                            IdPatient = 4,
                            Birthdate = new DateTime(2021, 7, 3, 15, 13, 29, 924, DateTimeKind.Local).AddTicks(5737),
                            FirstName = "Gregory",
                            LastName = "Glastname"
                        },
                        new
                        {
                            IdPatient = 5,
                            Birthdate = new DateTime(2021, 7, 3, 15, 13, 29, 924, DateTimeKind.Local).AddTicks(5740),
                            FirstName = "Henry",
                            LastName = "Hlastname"
                        });
                });

            modelBuilder.Entity("ClinicApi.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2021, 7, 3, 15, 13, 29, 929, DateTimeKind.Local).AddTicks(8442),
                            DueDate = new DateTime(2021, 7, 3, 15, 13, 29, 929, DateTimeKind.Local).AddTicks(8716),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2021, 7, 3, 15, 13, 29, 929, DateTimeKind.Local).AddTicks(8924),
                            DueDate = new DateTime(2021, 7, 3, 15, 13, 29, 929, DateTimeKind.Local).AddTicks(8932),
                            IdDoctor = 1,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("ClinicApi.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament");

                    b.HasIndex("IdMedicament");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 1,
                            Details = "Some details",
                            Dose = 1
                        },
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 4,
                            Details = "Some details"
                        },
                        new
                        {
                            IdPrescription = 2,
                            IdMedicament = 5,
                            Details = "Some details",
                            Dose = 2
                        });
                });

            modelBuilder.Entity("ClinicApi.Models.Prescription", b =>
                {
                    b.HasOne("ClinicApi.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicApi.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ClinicApi.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("ClinicApi.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicApi.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("ClinicApi.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ClinicApi.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("ClinicApi.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ClinicApi.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
