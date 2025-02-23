using Hope.DomainEntities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories.Repository
{
    public class AccountTypeRepository : Repository<AccountType> , IRepository.IAccountTypeRepository
    {
        public AccountTypeRepository()
        {

        }
    }
}
