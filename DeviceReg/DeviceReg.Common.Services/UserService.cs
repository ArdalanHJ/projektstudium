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
            return UnitOfWork.Users.GetUserById(id);
        }


        public IEnumerable<User> GetActiveUsers()
        {
            return UnitOfWork.Users.GetActiveUsers();
        }

        public UserProfile CreateProfile(UserProfile profile)
        {
            UnitOfWork.Profiles.Add(profile);
            return profile;
        }

    }
}
