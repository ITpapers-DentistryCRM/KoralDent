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

    public class StaffService : GenericService<Staff, StaffDTO, int>
    {
        public StaffService(IGenericRepository<Staff, int> repository) : base(repository)
        {


        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Staff, StaffDTO>()
                              .ForMember("AccountLogin", opt => opt.MapFrom(g => g.Account.AccountLogin))
                              .ForMember("AccountPassword", opt => opt.MapFrom(g => g.Account.AccountPassword));
                cfg.CreateMap<StaffDTO, Staff>();

            }).CreateMapper();
        }
    }
}
