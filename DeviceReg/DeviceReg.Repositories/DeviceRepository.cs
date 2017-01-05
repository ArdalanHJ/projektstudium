using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Repositories
{
    public class DeviceRepository : RepositoryBase<Device>
    {
        public DeviceRepository(DbSet<Device> dbSet) : base(dbSet)
        {

        }

        public IEnumerable<Device> GetAllByUserId(string userId)
        {
           return DbSet.Where(d => d.UserId == userId);
        }

        public Device GetBySerialNumber(string serialnumber)
        {
            return DbSet.FirstOrDefault(d => d.Serialnumber.Equals(serialnumber));
        }
    }
}
