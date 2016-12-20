using DeviceReg.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Repositories;
using DeviceReg.Common.Data.Models;

namespace DeviceReg.Services
{
    public class UserProfileService : AbstractService
    {
        public UserProfileService(UnitOfWork currentUnitOfWork) : base(currentUnitOfWork)
        {
        }

        public UserProfile GetByUserId(string userId)
        {
            var userProfile = UnitOfWork.Profiles.GetByUserId(userId);
            if(userProfile == null)
            {
                throw new Exception("Profile not found.");
            }
            return userProfile;
        }

        public bool Update(UserProfile userProfile)
        {
            if (userProfile == null) throw new Exception("Invalid user profile.");
            UnitOfWork.Profiles.Update(userProfile);
            return UnitOfWork.SaveChanges() > 0;
        }

    }
}
