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

    public class ServiceService : GenericService<Service, ServiceDTO, int>
    {
        public ServiceService(IGenericRepository<Service, int> repository) : base(repository)
        {

        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Service, ServiceDTO>()
                              .ForMember("SpecializationName", opt => opt.MapFrom(g => g.Specialization.SpecializationName));
                cfg.CreateMap<ServiceDTO, Service>();

            }).CreateMapper();
        }
    }
}
