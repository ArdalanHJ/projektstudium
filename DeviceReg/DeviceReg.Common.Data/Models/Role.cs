using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    [Table("AspNetRoles")]
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public string Id { get; set; }

        [Required]
        [Index("RoleNameIndex", IsUnique = true)]
        [MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
