using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.WebApi.Utility;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{
    [Authorize(Roles = "customer")]
    [RoutePrefix("api/user/devices")]
    public class DeviceController : ApiControllerBase
    {
        private DeviceService _deviceService;
        
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _deviceService = new DeviceService(UnitOfWork);
        }
        /// <summary>
        /// Create Device for User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route()]
        public IHttpActionResult Post([FromBody] DeviceModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return ControllerUtility.Guard(() =>
            {
                var device = new Device()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Serialnumber = model.SerialNumber,
                    RegularMaintenance = model.RegularMaintenance,
                    UserId = base.User.Identity.GetUserId(),
                    TypeOfDeviceId = model.TypeOfDeviceId,
                    MediumId = model.MediumId
                };

                _deviceService.Add(device);
                return base.Ok();

            });
        }
        /// <summary>
        /// Delete User device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if(_deviceService.DeviceBelongsToUser(id, User.Identity.GetUserId()))
                {
                    _deviceService.Delete(id);
                }

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Get All Devices of the current User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var x = base.User.Identity.GetUserId();
            return ControllerUtility.Guard(() =>
            {
                var devices = _deviceService.GetAllActiveByUserId(x);
                if (devices.Count() > 0)
                {
                    var deviceDtos = devices.Select(d => new DeviceDto(d)).ToList();
                     return Ok(deviceDtos);
                }

                return NotFound();
               
            });
        }
        /// <summary>
        /// Get specified Device of current User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return ControllerUtility.Guard(() =>
            {
                try
                {
                    var devices = _deviceService.GetAllActiveByUserId(User.Identity.GetUserId());
                    var device = devices.Where(d => d.Id.Equals(id)).First();
                    return base.Ok(new DeviceDto(device));
                }
                catch (Exception)
                {
                    return base.NotFound();
                }
            });
        }
        /// <summary>
        /// Update Device 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(DeviceModel model, int id)
        {
            return ControllerUtility.Guard(() => {
                var device = _deviceService.GetActiveByUserId(User.Identity.GetUserId(), id);
                device.Name = model.Name;
                device.Description = model.Description;
                device.Serialnumber = model.SerialNumber;
                device.RegularMaintenance = model.RegularMaintenance;
                _deviceService.Update(device);
                return Ok();
            });
        }
    }
}