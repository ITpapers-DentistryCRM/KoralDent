using Autofac.Core;
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

    public class Registration_ServiceService : GenericService<Registration_Service, Registration_ServiceDTO, int>
    {
        public Registration_ServiceService(IGenericRepository<Registration_Service, int> repository) : base(repository)
        {

        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Registration_Service, Registration_ServiceDTO>()
                              //.ForMember("Registration", opt => opt.MapFrom(g => g.Registration))
                              //.ForMember("Service", opt => opt.MapFrom(g => g.Service))
                              ;
                cfg.CreateMap<Registration_ServiceDTO, Registration_Service>();

            }).CreateMapper();
        }
    }
}
