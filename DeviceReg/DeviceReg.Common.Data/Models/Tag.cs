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
    public class Tag : IEntity
    {
        public Tag()
        {
            this.Devices = new HashSet<Device>();
        }

        public int Id { get; set; }

        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public String Name { get; set; }

        public Timestamp Timestamp { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

    }

    
}
