using DeviceReg.Common.Data.DeviceRegDB;
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

        UserRepository _users;

        public UserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_context.Users);

                return _users;
            }

        }

        private UserProfileRepository _profiles;

        public UserProfileRepository Profiles
        {
            get
            {
                if (_profiles == null)
                    _profiles = new UserProfileRepository(_context.UserProfiles);

                return _profiles;
            }

        }

        private RoleRepository _roles;

        public RoleRepository Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(_context.Roles);

                return _roles;
            }

        }

        private MediaRepository _media;

        public MediaRepository Media
        {
            get
            {
                if (_media == null)
                    _media = new MediaRepository(_context.Media);

                return _media;
            }

        }

        private TypeOfDeviceRepository _types;

        public TypeOfDeviceRepository Types
        {
            get
            {
                if (_types == null)
                    _types = new TypeOfDeviceRepository(_context.Types);

                return _types;
            }

        }
    }
}
