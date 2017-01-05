using DeviceReg.WebApi.Notifications;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.App_Start
{
    public class Platform
    {
        private static Platform instance = new Platform();

        static Platform()
        {
        }

        private Platform()
        {
         
        }

        public static Platform Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        public IScheduler Scheduler { get; private set; }
        
        public void Configure()
        {
            InitializeScheduler();

            var notificationsJobManager = new NotificationsJobManager();

            notificationsJobManager.Initialize();
        }

        private void InitializeScheduler()
        {
            NameValueCollection properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "Scheduler_" + this.GetType().FullName;
            properties["quartz.threadPool.threadCount"] = "10";

            ISchedulerFactory schedFact = new StdSchedulerFactory(properties);
            Scheduler = schedFact.GetScheduler();
            Scheduler.Start();
        }
    }
}