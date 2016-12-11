using System.Collections.Generic;

namespace DeviceReg.Common.Data.Models
{
    public class TypeOfDevice
    {
        public TypeOfDevice()
        {

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
    }
}