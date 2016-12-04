using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Models;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class UserRepository : IdentityRepositoryBase<AspNetUsers>
    {
        public UserRepository(DbSet<AspNetUsers> dbSet) : base(dbSet)
        {

        }
        public AspNetUsers GetUserByEmail(string email)
        {
            return DbSet.FirstOrDefault(u => u.Email == email);
        }


        public IEnumerable<AspNetUsers> GetActiveUsers()
        {
            return DbSet.Where(u => !u.LockoutEnabled);
        }

    }
}

