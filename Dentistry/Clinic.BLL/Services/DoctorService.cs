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
                              .ForMember("SpecializationName", opt => opt.MapFrom(g => g.Specialization.SpecializationName))
                              .ForMember("Staff", opt => opt.MapFrom(g => g.Staff));
                cfg.CreateMap<DoctorDTO, Doctor>();

            }).CreateMapper();
        }
    }
}
