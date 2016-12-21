using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Services.Utility
{
    public class ErrorHandler
    {
        public const string UserNotFound = "User not found.";
        public const string RoleNotFound = "Role not found.";
        public const string DeviceNotFound = "Device not found.";
        public const string ProfileNotFound = "Profile not found.";
        public const string InvalidConfirmationHash = "Invalid confirmation hash.";
        public const string InvalidEmail = "Invalid e-mail";
        public const string UserLockedOut = "User is locked out";
        public const string SecretAnswerMismatch = "Secret answer mismatch.";
        public const string InvalidDevice = "Invalid device.";
        public const string MediumNotFound = "Medium not found";
        public const string TypeOfDeviceNotFound = "Type of device not found.";
        public const string InvalidProfile = "Invalid user profile.";

        public static T Check<T>(T obj, string errorMsg)
        {
            if (obj == null) throw new Exception(errorMsg);
            return obj;
        }
    }
}
