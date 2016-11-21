﻿using DeviceReg.Common.Data.DeviceRegDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Repositories
{
    public class UnitOfWork
    {
        private readonly DeviceRegDBContext _context;

        public UnitOfWork(DeviceRegDBContext context)
        {
            _context = context;
        }

        DeviceRepository _devices;
        public DeviceRepository Devices
        {
            get
            {
                if (_devices == null)
                    _devices = new DeviceRepository(_context.Devices);

                return _devices;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
