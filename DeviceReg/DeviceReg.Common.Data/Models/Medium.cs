﻿using System.Collections.Generic;

namespace DeviceReg.Common.Data.Models
{
    public class Medium
    {
        public Medium()
        {
            Gas = false;
            Devices = new List<Device>();
        }
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public bool Gas
        {
            get; set;
        }
        public virtual ICollection<Device> Devices
        {
            get; set;
        }
    }
}