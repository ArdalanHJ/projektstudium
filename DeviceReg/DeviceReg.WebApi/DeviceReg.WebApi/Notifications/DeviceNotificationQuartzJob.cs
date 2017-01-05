using DeviceReg.Common.Data.DeviceRegDB;
using DeviceReg.Common.Services;
using DeviceReg.Repositories;
using DeviceReg.Services;
using DeviceReg.WebApi.App_Start;
using Quartz;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Notifications
{
    public class DeviceNotificationJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;

                var dbContext = new DeviceRegDBContext();
                var unitOfWork = new UnitOfWork(dbContext);
                var deviceService = new DeviceService(unitOfWork);
                var userService = new UserService(unitOfWork);
                var deviceNotificationService = new DeviceNotificationService(unitOfWork);


                //1)send maintenance notifications for devices

                var maintenanceRequiredDevices = deviceService.GetAllForRegularMaintenance(DateTime.UtcNow).ToList();

                foreach (var device in maintenanceRequiredDevices)
                {
                    var user = userService.GetUserById(device.UserId);
                    deviceNotificationService.SendRegularMaintenanceNotification(user, device);
                }

                //2) send calibration notifications for devices

                var calibrationRequiredDevices = deviceService.GetAllForRegularCalibration(DateTime.UtcNow).ToList();

                foreach (var device in calibrationRequiredDevices)
                {
                    var user = userService.GetUserById(device.UserId);
                    deviceNotificationService.SendRegularCalibrationNotification(user, device);
                }
            }
            catch (Exception exc)
            {
                throw new JobExecutionException(exc);
            }
        }
    }

    public class DeviceNotificationJobListener : IJobListener
    {
        public DeviceNotificationJobListener(object notificationService)
            : base()
        {
            this.notificationService = notificationService;
        }

        private object notificationService;

        public string Name
        {
            get { return "DeviceNotificationJobListener"; }
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            try
            {
                var msg = "";

                if (jobException != null)
                {
                    msg += "Jobexception: \n" + jobException.ToString() + "\n";
                }
            }
            catch (Exception exc)
            {
            }
        }

        public void JobExecutionVetoed(IJobExecutionContext context) { }
        public void JobToBeExecuted(IJobExecutionContext context) { }
    }

    public class DeviceNotificationQuartzJobStarter
    {
        private static readonly string JobName = "RegDevice";
        private static readonly string JobNamePrefix = "DeviceNotificationJob";

        public void Start()
        {
            var jobData = new JobDataMap();

            // construct job info
            IJobDetail jobDetail = JobBuilder.Create<DeviceNotificationJob>()
                .WithIdentity(JobNamePrefix + "_" + JobName)
                .UsingJobData(jobData)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("DeviceNotificationJobTrigger_" + JobName)
              .StartAt(DateTime.UtcNow.AddMinutes(1))
              .WithSimpleSchedule(x => x.WithIntervalInMinutes(5).RepeatForever().WithMisfireHandlingInstructionFireNow())
              .Build();

            var scheduler = Platform.Instance.Scheduler;

            var _databaseBackupJobListener = new DeviceNotificationJobListener(null);
            scheduler.ListenerManager.AddJobListener(_databaseBackupJobListener, NameMatcher<JobKey>.NameContains(JobNamePrefix));
            scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}