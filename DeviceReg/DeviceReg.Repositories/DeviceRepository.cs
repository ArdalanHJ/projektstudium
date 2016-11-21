﻿using DeviceReg.Common.Data.Models;
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
    }
}
