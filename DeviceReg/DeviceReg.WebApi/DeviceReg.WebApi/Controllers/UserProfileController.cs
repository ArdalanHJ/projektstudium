using DeviceReg.Common.Data.Models;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
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
    [Authorize(Roles = "Customer")]
    [RoutePrefix("api/user")]
    public class UserProfileController : ApiControllerBase
    {


        /// <summary>
        /// Initialize Services
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

        }
        /// <summary>
        /// Returns User profile of the current User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetUserProfile()
        {
            return NotFound();
        }
        /// <summary>
        /// Update Profile of the current User
        /// </summary>
        /// <param name="userProfileModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route()]
        public IHttpActionResult UpdateUser()
        {
            return NotFound();
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