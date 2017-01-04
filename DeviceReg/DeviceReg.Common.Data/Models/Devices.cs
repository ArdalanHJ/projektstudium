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
            Tags = new List<Tag>();
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
        public string Description
        {
            get; set;
        }

        [MaxLength(9)]
        [Index("SerialNumberIndex", IsUnique = true)]
        public string Serialnumber
        {
            get; set;
        }
        public bool RegularMaintenance
        {
            get; set;
        }
        //public bool RegularCalibration
        //{
        //    get; set;
        //}

        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int TypeOfDeviceId { get; set; }

        [ForeignKey("TypeOfDeviceId")]
        public TypeOfDevice TypeOfDevice { get; set; }

        [Required]
        public int MediumId { get; set; }

        [ForeignKey("MediumId")]
        public Medium Medium { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Timestamp Timestamp { get; set; }

    }
}
