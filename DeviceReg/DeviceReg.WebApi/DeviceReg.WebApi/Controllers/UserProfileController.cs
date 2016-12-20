using DeviceReg.Common.Data.Models;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.WebApi.Utility;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{
    /// <summary>
    /// Controller for UserProfile
    /// </summary>
    [Authorize(Roles = "customer")]
    [RoutePrefix("api/user/profile")]
    public class UserProfileController : ApiControllerBase
    {
        private UserProfileService _userProfileService;

        /// <summary>
        /// Initialize Services
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            
            _userProfileService = new UserProfileService(UnitOfWork);
        }
        /// <summary>
        /// Returns User profile of the current User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetUserProfile()
        {
            return ControllerUtility.Guard(() =>
            {
                var currentUserId = User.Identity.GetUserId();
                var userProfile = new UserProfileUserViewBindingModel(_userProfileService.GetByUserId(currentUserId));
                return Ok(userProfile);
            });
        }
        /// <summary>
        /// Update Profile of the current User
        /// </summary>
        /// <param name="userProfileModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route()]
        public IHttpActionResult UpdateUser(UserProfileUserViewBindingModel userProfileModel)
        {
            return ControllerUtility.Guard(() =>
            {
                var currentUserId = User.Identity.GetUserId();
                var currentUserProfile = _userProfileService.GetByUserId(currentUserId);
                currentUserProfile.Gender = (int) userProfileModel.Gender;
                currentUserProfile.Prename = userProfileModel.Prename;
                currentUserProfile.Surname = userProfileModel.Surname;
                currentUserProfile.Language = (int) userProfileModel.Language;
                currentUserProfile.Phone = userProfileModel.Phone;

                currentUserProfile.IndustryFamilyType = (int) userProfileModel.IndustryFamilyType;
                currentUserProfile.IndustryType = userProfileModel.IndustryType;
                currentUserProfile.CompanyName = userProfileModel.CompanyName;
                currentUserProfile.Street = userProfileModel.Street;
                currentUserProfile.StreetNumber = userProfileModel.StreetNumber;
                currentUserProfile.ZipCode = userProfileModel.ZipCode;
                currentUserProfile.City = userProfileModel.City;
                currentUserProfile.Country = userProfileModel.Country;

                _userProfileService.Update(currentUserProfile);

                return Ok();
            });
        }
        /// <summary>
        /// Request Delete of user
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route()]
        public IHttpActionResult RequestDelete()
        {
            return NotFound();
        }
    }
}