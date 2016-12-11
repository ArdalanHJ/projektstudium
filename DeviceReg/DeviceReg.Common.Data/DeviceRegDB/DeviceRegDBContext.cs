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
    public class DeviceRegDBContext:DbContext
    {
        
        public DeviceRegDBContext():base("DefaultConnection") {
            Database.SetInitializer(new DeviceRegDBInitializer());
        }
        public virtual DbSet<Device> Devices
        {
            get; set;
        }
        public virtual DbSet<User> Users
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

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Claim> Claims { get; set; }

        public virtual DbSet<UserLogin> UserLogins { get; set; }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public object UserRoles { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
               .HasMany<Role>(s => s.Roles)
               .WithMany(c => c.Users)
               .Map(cs =>
               {
                   cs.MapLeftKey("UserId");
                   cs.MapRightKey("RoleId");
                   cs.ToTable("AspNetUserRoles");
               });

            // one-to-one relation between UserProfile and User
            modelBuilder.Entity<UserProfile>()
                .HasKey(e => e.UserId);

            modelBuilder.Entity<User>()
                        .HasRequired(s => s.Profile)
                        .WithRequiredPrincipal(ad => ad.User)
                        .WillCascadeOnDelete(false);
        }
    }
}


