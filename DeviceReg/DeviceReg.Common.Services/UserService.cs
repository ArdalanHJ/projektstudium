using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Repositories;
using DeviceReg.Common.Data.Models;

namespace DeviceReg.Services
{
    class UserService : Abstract.AbstractService
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AspNetUsers GetUserByEmail(string email)
        {
            return UnitOfWork.Users.GetUserByEmail(email);
        }


        public IEnumerable<AspNetUsers> GetActiveUsers()
        {
            return UnitOfWork.Users.GetActiveUsers();
        }

    }
}
