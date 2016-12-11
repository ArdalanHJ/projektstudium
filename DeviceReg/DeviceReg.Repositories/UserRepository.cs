using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Models;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class UserRepository : IdentityRepositoryBase<User>
    {
        public UserRepository(DbSet<User> dbSet) : base(dbSet)
        {

        }
        public User GetUserByEmail(string email)
        {
            return DbSet.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(string id)
        {
            return DbSet.FirstOrDefault(u => u.Id == id);
        }


        public IEnumerable<User> GetActiveUsers()
        {
            return DbSet.Where(u => !u.LockoutEnabled);
        }

    }
}

