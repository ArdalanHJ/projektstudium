using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
   public class UserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
