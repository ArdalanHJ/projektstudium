using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Repositories;
using DeviceReg.Common.Data.Models;
using DeviceReg.Services.Utility;

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
           var user = ErrorHandler.Check(UnitOfWork.Users.GetUserById(id), ErrorHandler.UserNotFound);
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
            var profile = ErrorHandler.Check(UnitOfWork.Profiles.GetUserByConfirmationHash(confirmationHash), ErrorHandler.InvalidConfirmationHash);
            var user = ErrorHandler.Check(UnitOfWork.Users.GetUserById(profile.UserId), ErrorHandler.UserNotFound);
            user.EmailConfirmed = true;
            profile.ConfirmationHash = null;
            UnitOfWork.SaveChanges();
            return true;
        }

        public bool ResetPassword(string userEmail, string secretAnswerHash, string newConfirmationHash)
        {
            var user = ErrorHandler.Check(UnitOfWork.Users.GetUserByEmail(userEmail), ErrorHandler.InvalidEmail);
            if (user.LockoutEnabled)  throw new Exception(ErrorHandler.UserLockedOut);
            var profile = ErrorHandler.Check(UnitOfWork.Profiles.GetByUserId(user.Id), ErrorHandler.ProfileNotFound);
            if (secretAnswerHash != profile.SecretAnswer) throw new Exception(ErrorHandler.SecretAnswerMismatch);
            profile.ConfirmationHash = newConfirmationHash;
            UnitOfWork.SaveChanges();
            return true;
        }

        public bool AddRoleToUser(string userId, string roleName)
        {
            var user = ErrorHandler.Check(UnitOfWork.Users.GetUserById(userId), ErrorHandler.UserNotFound);
            var role = ErrorHandler.Check(UnitOfWork.Roles.GetRoleByName(roleName), ErrorHandler.RoleNotFound);
            user.Roles.Add(role);
            UnitOfWork.SaveChanges();
            return true;
        }
    }
}
