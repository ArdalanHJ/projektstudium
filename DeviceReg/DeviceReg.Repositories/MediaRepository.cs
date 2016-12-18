using System.Data.Entity;
using DeviceReg.Common.Data.Models;

namespace DeviceReg.Repositories
{
    public class MediaRepository : RepositoryBase<Medium>
    {
        public MediaRepository(DbSet<Medium> dbSet) : base(dbSet)
        {
        }
    }
}