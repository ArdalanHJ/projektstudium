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

        public bool Add(Device device)
        {

            if (IsValidDevice(device))
            {
                UnitOfWork.Devices.Add(device);
                UnitOfWork.SaveChanges();
            }

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
            IsValidUser(userId);
            
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
            var device = UnitOfWork.Devices.GetById(deviceId);
            if(device == null)
            {
                throw new Exception("Device not found.");
            }

            return device;
        }

        public bool Update(Device device)
        {
            if (IsValidDevice(device))
            {
                UnitOfWork.Devices.Update(device);
                UnitOfWork.SaveChanges();
            }

            return true;
        }

        public bool DeleteAllByUserId(string userId)
        {
                IsValidUser(userId);

                var devices = UnitOfWork.Devices.GetAllByUserId(userId);

                foreach (Device device in devices)
                {
                    UnitOfWork.Devices.Delete(device);
                }

                return UnitOfWork.SaveChanges() > 0;
        }

        private bool IsValidUser(string userId)
        {
            var user = UnitOfWork.Users.GetUserById(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return true;
        }

        private bool IsValidDevice(Device device)
        {
            if (device == null)
            {
                throw new Exception("Invalid device");
            }

            var medium = UnitOfWork.Media.GetById(device.MediumId);

            if (medium == null)
            {
                throw new Exception("Medium not found");
            }

            var typeOfDevice = UnitOfWork.Types.GetById(device.TypeOfDeviceId);

            if (typeOfDevice == null)
            {
                throw new Exception("Type of device not found");
            }

            return true;
        }
    }
}
