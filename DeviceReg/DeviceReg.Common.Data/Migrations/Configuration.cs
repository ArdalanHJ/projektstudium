namespace DeviceReg.Common.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<DeviceReg.Common.Data.DeviceRegDB.DeviceRegDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeviceReg.Common.Data.DeviceRegDB.DeviceRegDBContext context)
        {
            seedUserWithRole("admin", "admin@devicereg.de", "Admin12!", context);
            seedUserWithRole("support", "support@devicereg.de", "Support12!", context);
            seedUserWithRole("customer", "customer@devicereg.de", "Customer12!", context);
        }

        public void seedUserWithRole(string roleName, string userName, string password, DeviceReg.Common.Data.DeviceRegDB.DeviceRegDBContext context)
        {
            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var role = new Role();
                role.Id = HashPassword(roleName);
                role.Name = roleName;
                context.Roles.Add(role);
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == userName))
            {
                // TODO: UserProfile?
                var user = new User();
                user.Id = Guid.NewGuid().ToString("D");
                user.Email = userName;
                user.UserName = user.Email;
                user.EmailConfirmed = true;
                user.PasswordHash = HashPassword(password);
                user.SecurityStamp = Guid.NewGuid().ToString("D");
                user.Roles.Add(context.Roles.FirstOrDefault(r => r.Name == roleName));
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // TODO: Transfer this method to utility class (to be implemented, but where?).
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}
