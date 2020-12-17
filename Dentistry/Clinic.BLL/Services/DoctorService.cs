using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Clinic.BLL.Models;
using Clinic.DAL.DomainModels;
using Clinic.BLL.Services;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Clinic.BLL.Infrastructure;

namespace Clinic.BLL.Services
{

    public class DoctorService : GenericService<Doctor, DoctorDTO, int>
    {
        public DoctorService(IGenericRepository<Doctor, int> repository) : base(repository)
        {


        }
            
        public override IMapper GetMapper()
        {

            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Doctor, DoctorDTO>()
                              .ForMember(d => d.SpecializationName, opt => opt.MapFrom(g => g.Specialization.SpecializationName))
                              .ForMember(d => d.StaffLastName, opt => opt.MapFrom( g=> g.Staff.StaffLastName ))
                              .ForMember(d => d.StaffName, opt => opt.MapFrom(g => g.Staff.StaffName))
                              .ForMember(d => d.StaffMiddleName, opt => opt.MapFrom(g => g.Staff.StaffMiddleName))
                              .ForMember(d => d.StaffSalary, opt => opt.MapFrom(g => g.Staff.StaffSalary))
                              .ForMember(d => d.StaffBirthday, opt => opt.MapFrom(g => g.Staff.StaffBirthday))
                              .ForMember(d => d.AccountId, opt => opt.MapFrom(g => g.Staff.AccountId))
                              .ForMember(d => d.AccountLogin, opt => opt.MapFrom(g => g.Staff.Account.AccountLogin))
                              .ForMember(d => d.AccountPassword, opt => opt.MapFrom(g => g.Staff.Account.AccountPassword))
                              .ForMember(d => d.AccountLevel, opt => opt.MapFrom(g => g.Staff.AccountLevel));
                cfg.CreateMap<DoctorDTO, Doctor>();

            }).CreateMapper();
        }
    }
}
