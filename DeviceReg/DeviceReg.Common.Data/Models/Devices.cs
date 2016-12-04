using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class Device : IEntity
    {
        public Device()
        {
            Timestamp = new Timestamp();
            Tags = new List<Tag>();
        }

        public int Id
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string Serialnumber
        {
            get; set;
        }
        //public string PersonalTag
        //{
        //    get; set;
        //}
        public bool RegularMaintenance
        {
            get; set;
        }
        //public bool RegularCalibration
        //{
        //    get; set;
        //}
        //public string Text
        //{
        //    get; set;
        //}

        //public int TypeOfDeviceId
        //{
        //    get; set;
        //}
        //public TypeOfDevice TypeOfDevice
        //{
        //    get; set;
        //}

        //public int MediumId
        //{
        //    get; set;
        //}
        //public Medium Medium
        //{
        //    get; set;
        //}

        public Timestamp Timestamp { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual User User { get; set; }


    }
}
