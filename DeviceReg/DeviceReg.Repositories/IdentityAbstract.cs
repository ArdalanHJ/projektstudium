using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Repositories
{
    public class IdentityRepositoryBase<T> where T : class
    {
        protected virtual DbSet<T> DbSet { get; private set; }

        public IdentityRepositoryBase(DbSet<T> dbSet)
        {
            this.DbSet = dbSet;
        }

    }
}
