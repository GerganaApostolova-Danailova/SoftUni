using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=TCECO\WINCC;Database=HospitalDatabase;Integrated Security=true;");
            }
        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entiry =>
            {
                entiry.Property(e => e.Email)
                .IsUnicode(false);
            });

            modelBuilder.Entity<PatientMedicament>(entiry =>
            {
                entiry.HasKey(e=> new { e.PatientId, e.MedicamentId});
            });
        }
    }
}
