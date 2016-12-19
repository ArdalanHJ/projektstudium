using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
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
    /// Controller for Label
    /// </summary>
    [Authorize(Roles = "Customer")]
    [RoutePrefix("api/user/label")]
    public class LabelController : ApiControllerBase
    {
        /// <summary>
        /// Initialize Services
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var userId = User.Identity.GetUserId();
        }

        /// <summary>
        /// Return all Devices associated with given Label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{label}")]
        public IHttpActionResult GetDevicesWithTag(string label)
        {
            return NotFound();
        }
        /// <summary>
        /// Deletes a Label from a Device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public IHttpActionResult RemoveTagFromDevice([FromBody] string deviceId, [FromBody] string label)
        {
            return NotFound();
        }
        /// <summary>
        /// Deletes all Devices with a Label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{label}/removeAll")]
        public IHttpActionResult DeleteAllDevicesWithTag(string label)
        {
            return NotFound();
        }
    }
}