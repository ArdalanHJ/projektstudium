using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models
{
    public class DeviceModel
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public Boolean RegularMaintenance { get; set; }

        public int TypeOfDeviceId { get; set; }

        public int MediumId { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}