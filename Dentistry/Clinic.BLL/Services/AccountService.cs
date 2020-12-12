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

    public class AccountService : GenericService<Account, AccountDTO, int>
    {
        public AccountService(IGenericRepository<Account, int> repository) : base(repository)
        {
        }
    }
}
