using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>
    {
        public UserProfileRepository(DbSet<UserProfile> dbSet) : base(dbSet)
        {
        }

        public UserProfile GetUserByConfirmationHash(string confirmationHash)
        {
            return DbSet.FirstOrDefault(up => up.ConfirmationHash == confirmationHash);
        }
    }
}
