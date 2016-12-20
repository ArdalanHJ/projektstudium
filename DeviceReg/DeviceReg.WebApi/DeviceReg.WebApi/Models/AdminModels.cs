using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models
{
    public class UserIdBindingModel
    {
        public string UserId { get; set; }
    }

    public class CreateDeviceForUserBindingModel
    {
        public string UserId { get; set; }

        public DeviceModel Device { get; set; }
    }

    public class UpdateDeviceBindingModel
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public Boolean RegularMaintenance { get; set; }

        public int TypeOfDeviceId { get; set; }

        public int MediumId { get; set; }
    }
}