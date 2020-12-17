using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Clinic.BLL.Models;
using Clinic.DAL.DomainModels;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Services
{

    public class RegistrationService : GenericService<Registration, RegistrationDTO, int>
    {
        public RegistrationService(IGenericRepository<Registration, int> repository) : base(repository)
        {

        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Registration, RegistrationDTO>()
                              //.ForMember("Doctor", opt => opt.MapFrom(g => g.Doctor))
                              //.ForMember("Patient", opt => opt.MapFrom(g => g.Patient))
                              .ForMember("RegistrationStatusName", opt => opt.MapFrom(g => g.RegistrationStatus.RegistrationStatusName))
                              .ForMember("RegistrationStatusInfo", opt => opt.MapFrom(g => g.RegistrationStatus.RegistrationStatusInfo)); 
                cfg.CreateMap<RegistrationDTO, Registration>();

            }).CreateMapper();
        }
    }
}
