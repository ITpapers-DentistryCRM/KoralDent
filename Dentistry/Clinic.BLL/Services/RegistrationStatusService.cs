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

    public class RegistrationStatusService : GenericService<RegistrationStatus, RegistrationStatusDTO, int>
    {
        public RegistrationStatusService(IGenericRepository<RegistrationStatus, int> repository) : base(repository)
        {
        }
    }
}
