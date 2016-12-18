using System.Data.Entity;
using DeviceReg.Common.Data.Models;

namespace DeviceReg.Repositories
{
    public class TypeOfDeviceRepository : RepositoryBase<TypeOfDevice>
    {
        public TypeOfDeviceRepository(DbSet<TypeOfDevice> dbSet) : base(dbSet)
        {
        }
    }
}