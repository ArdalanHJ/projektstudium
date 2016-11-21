using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class Device : IEntity
    {
        public Device()
        {
            this.Timestamp = new Timestamp();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Serialnumber { get; set; }

        public bool RegularMaintenance { get; set; }

        public bool RegularCalibration { get; set; }

        public string Description { get; set; }

        public virtual TypeOfDevice TypeOfDevice { get; set; }

        public virtual Medium Medium { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Timestamp Timestamp { get; set; }

    }
}
