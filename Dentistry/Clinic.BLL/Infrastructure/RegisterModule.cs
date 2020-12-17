using Autofac;
using Clinic.BLL.Models;
using Clinic.BLL.Services;
using Clinic.DAL.DomainModels;
using Clinic.Repository.Repositories;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Infrastructure
{
    public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(StaffService))
                            .As(typeof(IGenericService<StaffDTO, int>));
            builder.RegisterType(typeof(StaffRepository))
                            .As(typeof(IGenericRepository<Staff, int>));


            builder.RegisterType(typeof(SpecializationService))
                            .As(typeof(IGenericService<SpecializationDTO, int>));
            builder.RegisterType(typeof(SpecializationRepository))
                            .As(typeof(IGenericRepository<Specialization, int>));

            builder.RegisterType(typeof(ServiceService))
                            .As(typeof(IGenericService<ServiceDTO, int>));
            builder.RegisterType(typeof(ServiceRepository))
                            .As(typeof(IGenericRepository<Service, int>));

            builder.RegisterType(typeof(RegistrationStatusService))
                            .As(typeof(IGenericService<RegistrationStatusDTO, int>));
            builder.RegisterType(typeof(RegistrationStatusRepository))
                            .As(typeof(IGenericRepository<RegistrationStatus, int>));

            builder.RegisterType(typeof(RegistrationService))
                            .As(typeof(IGenericService<RegistrationDTO, int>));
            builder.RegisterType(typeof(RegistrationRepository))
                            .As(typeof(IGenericRepository<Registration, int>));

            builder.RegisterType(typeof(Registration_ServiceService))
                            .As(typeof(IGenericService<Registration_ServiceDTO, int>));
            builder.RegisterType(typeof(Registration_ServiceRepository))
                            .As(typeof(IGenericRepository<Registration_Service, int>));

            builder.RegisterType(typeof(PatientService))
                            .As(typeof(IGenericService<PatientDTO, int>));
            builder.RegisterType(typeof(PatientRepository))
                            .As(typeof(IGenericRepository<Patient, int>));

            builder.RegisterType(typeof(DoctorService))
                            .As(typeof(IGenericService<DoctorDTO, int>));
            builder.RegisterType(typeof(DoctorRepository))
                            .As(typeof(IGenericRepository<Doctor, int>));

            builder.RegisterType(typeof(AccountService))
                            .As(typeof(IGenericService<AccountDTO, int>));
            builder.RegisterType(typeof(AccountRepository))
                            .As(typeof(IGenericRepository<Account, int>));


            builder.RegisterType(typeof(ClinicContext))
                           .As(typeof(DbContext));

        }

    }
}
