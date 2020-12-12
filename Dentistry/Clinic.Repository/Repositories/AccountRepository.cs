﻿using Clinic.DAL.DomainModels;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repository.Repositories
{

    public class AccountRepository : GenericRepository<Account, int>
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }
    }
}
