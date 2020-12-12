using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Clinic.DAL.DomainModels
{
    public partial class ClinicContext : DbContext
    {
        public ClinicContext()
            : base("name=ClinicContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Registration_Service> Registration_Service { get; set; }
        public virtual DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .HasMany(e => e.Registration_Service)
                .WithRequired(e => e.Registration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistrationStatus>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.RegistrationStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Registration_Service)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.Specialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Specialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);
        }
    }
}
