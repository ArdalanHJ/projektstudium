using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class RoleRepository : IdentityRepositoryBase<Role>
    {
        public RoleRepository(DbSet<Role> dbSet) : base(dbSet)
        {
        }

        public Role GetRoleByName(string roleName)
        {
            return DbSet.FirstOrDefault(r => r.Name == roleName);
        }
    }
}
