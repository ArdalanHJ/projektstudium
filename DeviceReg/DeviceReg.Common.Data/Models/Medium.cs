using DeviceReg.Common.Data.Models.ComplexTypes;
using System.Collections.Generic;

namespace DeviceReg.Common.Data.Models
{
    public class Medium
    {
        public Medium()
        {
            this.Timestamp = new Timestamp();
        }
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public bool IsGas
        {
            get; set;
        }

        public Timestamp Timestamp { get; set; }

        public virtual ICollection<Device> Devices
        {
            get; set;
        }
    }
}