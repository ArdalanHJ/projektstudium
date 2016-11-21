using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    //Tip : we sholud sync prop of this class with User table of indentity
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }

        [Required]
        public String Email { get; set; }

        public String Password { get; set; }

        public virtual UserProfile Profile { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
               

    }
    
}
