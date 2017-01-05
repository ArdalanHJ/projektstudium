using DeviceReg.Services.Abstract;
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
    public class UserProfileService : AbstractService
    {
        public UserProfileService(UnitOfWork currentUnitOfWork) : base(currentUnitOfWork)
        {
        }

        public UserProfile GetByUserId(string userId)
        {
           return ErrorHandler.Check(UnitOfWork.Profiles.GetByUserId(userId), ErrorHandler.ProfileNotFound);
        }

        public bool Update(UserProfile userProfile)
        {
            UnitOfWork.Profiles.Update(ErrorHandler.Check(userProfile, ErrorHandler.InvalidProfile));
            return UnitOfWork.SaveChanges() > 0;
        }

    }
}
