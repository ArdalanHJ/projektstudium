using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeviceReg.Common.Data.Models
{
    [Table("AspNetUsers")]
    public class User
    {
        public User()
        {
            Devices = new List<Device>();
            Roles = new List<Role>();
        }

        public string Id { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [MaxLength(256)]
        [Index("UserNameIndex", IsUnique = true)]
        public string UserName { get; set; }

        public ICollection<Device> Devices { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual UserProfile Profile { get; set; }

    }
}
