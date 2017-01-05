using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Notifications
{
    public class NotificationsJobManager
    {
        public NotificationsJobManager()
        {

        }

        public void Initialize()
        {
            StartDeviceNotification();
        }

        private void StartDeviceNotification()
        {
            var js = new DeviceNotificationQuartzJobStarter();
            js.Start();
        }
    }
}