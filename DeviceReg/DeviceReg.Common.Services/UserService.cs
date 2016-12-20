using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Repositories;
using DeviceReg.Common.Data.Models;

namespace DeviceReg.Services
{
    public class UserService : Abstract.AbstractService
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetUserByEmail(string email)
        {
            return UnitOfWork.Users.GetUserByEmail(email);
        }

        public User GetUserById(string id)
        {
            var user = UnitOfWork.Users.GetUserById(id);
            if (user == null) throw new Exception("User not found.");
            return user;
        }


        public IEnumerable<User> GetActiveUsers()
        {
            return UnitOfWork.Users.GetActiveUsers();
        }

        public UserProfile CreateProfile(UserProfile profile)
        {
            UnitOfWork.Profiles.Add(profile);
            UnitOfWork.SaveChanges();
            return profile;
        }

        public bool ConfirmUser(string confirmationHash)
        {
           var profile = UnitOfWork.Profiles.GetUserByConfirmationHash(confirmationHash);
            if(profile != null)
            {
                var user = UnitOfWork.Users.GetUserById(profile.UserId);
                if(user != null)
                {
                    user.EmailConfirmed = true;
                    profile.ConfirmationHash = null;
                    UnitOfWork.SaveChanges();
                    return true;
                }
                throw new Exception("User not found.");
            }
            throw new Exception("Invalid confirmation hash");
        }

        public bool ResetPassword(string userEmail, string secretAnswerHash, string newConfirmationHash)
        {
            var user = UnitOfWork.Users.GetUserByEmail(userEmail);

            if(user == null)
            {
                throw new Exception("Invalid e-mail.");
            }

            if (user.LockoutEnabled)
            {
                throw new Exception("User is locked out.");
            }

            var profile = UnitOfWork.Profiles.GetByUserId(user.Id);

            if(profile == null)
            {
                throw new Exception("User profile missing.");
            }

            if (secretAnswerHash != profile.SecretAnswer)
            {
                throw new Exception("Secret answer mismatch.");
            }

            profile.ConfirmationHash = newConfirmationHash;

            UnitOfWork.SaveChanges();

            return true;
        }

        public bool AddRoleToUser(string userId, string roleName)
        {
            var user = UnitOfWork.Users.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var role = UnitOfWork.Roles.GetRoleByName(roleName);

            if(role == null)
            {
                throw new Exception("Role not found.");
            }

            user.Roles.Add(role);
            UnitOfWork.SaveChanges();
            return true;
        }
    }
}
