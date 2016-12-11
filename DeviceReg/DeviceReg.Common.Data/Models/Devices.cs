using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Timestamp Timestamp { get; set; }

    }
}
