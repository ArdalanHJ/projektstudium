using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using DeviceReg.Services;
using DeviceReg.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Services
{
    public class DeviceService : AbstractService
    {
        public DeviceService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void AddDevice(Device device, string email)
        {
            var userService = new UserService(UnitOfWork);

            var user = userService.GetUserByEmail(email);

            if (user != null)
            {
                UnitOfWork.Devices.Add(device);

                UnitOfWork.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid user");
            }
        }

        public bool Delete(int id)
        {
            var device = UnitOfWork.Devices.GetById(id);

            if (device != null)
            {
                UnitOfWork.Devices.Delete(device);
                return UnitOfWork.SaveChanges() > 0;
            }

            return false;
        }
    }
}
