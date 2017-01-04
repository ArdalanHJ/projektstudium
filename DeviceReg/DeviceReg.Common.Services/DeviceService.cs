using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using DeviceReg.Services;
using DeviceReg.Services.Abstract;
using DeviceReg.Services.Utility;
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

        public bool Add(Device device)
        {
            CheckDevice(device);
            UnitOfWork.Devices.Add(device);
            UnitOfWork.SaveChanges();
            return true;
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

        public IEnumerable<Device> GetAllByUserId(string userId)
        {
            ErrorHandler.Check(UnitOfWork.Users.GetUserById(userId), ErrorHandler.UserNotFound);
            var devices = UnitOfWork.Devices.GetAllByUserId(userId);
            return devices;
        }

        public IEnumerable<Device> GetAllActiveByUserId(string userId)
        {
            return GetAllByUserId(userId).Where(d => d.Timestamp.Deleted == null);
        }

        public IEnumerable<Device> GetAllDeletedByUserId(string userId)
        {
            return GetAllByUserId(userId).Where(d => d.Timestamp.Deleted != null);
        }

        public Device GetById(int deviceId)
        {
            var device = ErrorHandler.Check(UnitOfWork.Devices.GetById(deviceId), ErrorHandler.DeviceNotFound);
            return device;
        }

        public bool Update(Device device)
        {
            CheckDevice(device);
            UnitOfWork.Devices.Update(device);
            UnitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteAllByUserId(string userId)
        {
            ErrorHandler.Check(UnitOfWork.Users.GetUserById(userId), ErrorHandler.UserNotFound);
            var devices = UnitOfWork.Devices.GetAllByUserId(userId);

            foreach (Device device in devices)
            {
                UnitOfWork.Devices.Delete(device);
            }

            return UnitOfWork.SaveChanges() > 0;
        }

        public IEnumerable<Device> GetAllForRegularMaintenance(DateTime date)
        {
            var result = UnitOfWork.Devices.GetAll().Where(dev => dev.RegularMaintenance);

            return result;
        }

        public IEnumerable<Device> GetAllForRegularCalibration(DateTime date)
        {
            var result = UnitOfWork.Devices.GetAll().Where(dev => dev.RegularMaintenance);

            return result;
        }

        private void CheckDevice(Device device)
        {
            ErrorHandler.Check(device, ErrorHandler.InvalidDevice);
            ErrorHandler.Check(UnitOfWork.Media.GetById(device.MediumId), ErrorHandler.MediumNotFound);
            ErrorHandler.Check(UnitOfWork.Types.GetById(device.TypeOfDeviceId), ErrorHandler.TypeOfDeviceNotFound);
        }
    }
}
