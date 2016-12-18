using DeviceReg.Common.Data.Interfaces;
using System.Collections.Generic;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;

namespace DeviceReg.Common.Data.Models
{
    public class TypeOfDevice: IEntity
    {
        public TypeOfDevice()
        {
            Devices = new List<Device>();
            Timestamp = new Timestamp();
        }
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public virtual ICollection<Device> Devices
        {
            get; set;
        }

        public Timestamp Timestamp { get; set; }
        
    }
}