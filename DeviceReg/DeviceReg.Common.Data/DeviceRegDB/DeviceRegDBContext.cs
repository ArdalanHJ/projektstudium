using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeviceReg.Common.Data.DeviceRegDB
{

    //public class DeviceRegDBContext : IdentityDbContext<ApplicationUser>
    public class DeviceRegDBContext:DbContext
    {
        
        public DeviceRegDBContext():base("DefaultConnection") {
            Database.SetInitializer(new DeviceRegDBInitializer());
        }
        public virtual DbSet<Device> Devices
        {
            get; set;
        }

        public virtual DbSet<AspNetUsers> AspNetUsers
        {
            get; set;
        }
        //public virtual DbSet<Medium> Mediums
        //{
        //    get; set;
        //}
        //public virtual DbSet<TypeOfDevice> Types
        //{
        //   get; set;
        //}
    }
}


