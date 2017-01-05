using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Notifications.Internal
{
    public class NotificationMessage
    {
        public NotificationMessage(string notificationTemplateKey, User receiver, Dictionary<String, String> parameters)
        {
            NotificationSubjectTemplateKey = string.Format("{0}_{1}", notificationTemplateKey, "Subject");
            NotificationTextTemplateKey = string.Format("{0}_{1}", notificationTemplateKey, "Text");
            Receiver = receiver;
            Parameters = parameters;
        }

        public String NotificationSubjectTemplateKey { get; private set; }

        public String NotificationTextTemplateKey { get; private set; }


        public Dictionary<String, String> Parameters { get; private set; }

        public User Receiver { get; private set; }
    }
}