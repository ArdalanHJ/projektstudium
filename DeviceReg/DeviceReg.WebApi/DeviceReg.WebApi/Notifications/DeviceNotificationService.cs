using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using DeviceReg.WebApi.Notifications.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Notifications
{
    public class DeviceNotificationService : AbstractNotificationService
    {
        public DeviceNotificationService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void SendRegularMaintenanceNotification(User receiver, Device device)
        {
            var notificationParameters = GetNotificationParameters(receiver, device);
            var notificationMessage = new NotificationMessage("RegularMaintenanceNotification", receiver, notificationParameters);

            SendNotificationAsync(notificationMessage);
        }


        public void SendRegularCalibrationNotification(User receiver, Device device)
        {
            var notificationParameters = GetNotificationParameters(receiver, device);
            var notificationMessage = new NotificationMessage("RegularCalibrationNotification", receiver, notificationParameters);

            SendNotificationAsync(notificationMessage);
        }



        private Dictionary<String, String> GetNotificationParameters(User user, Device device)
        {
            var parameters = new Dictionary<String, String>();

            parameters.Add("Prename", user.Profile.Prename);
            parameters.Add("Surname", user.Profile.Surname);
            parameters.Add("CompanyName", user.Profile.CompanyName);
            parameters.Add("DeviceName", device.Name);
            parameters.Add("DeviceSerialnumber", device.Serialnumber);

            return parameters;
        }
    }
}