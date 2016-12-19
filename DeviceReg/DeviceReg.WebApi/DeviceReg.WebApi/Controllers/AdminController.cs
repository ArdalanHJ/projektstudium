using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.WebApi.Models.DTOs;
using DeviceReg.WebApi.Utility;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{
    [Authorize(Roles = "admin")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiControllerBase
    {
        private UserService _userService;
        private DeviceService _deviceService;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            _userService = new UserService(UnitOfWork);
            _deviceService = new DeviceService(UnitOfWork);

        }

        /// <summary>
        /// Creates a device for a specific user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("device")]
        public IHttpActionResult CreateDeviceForUser(CreateDeviceForUserBindingModel model)
        {
            return ControllerUtility.Guard(() =>
            {
                var user = _userService.GetUserById(model.UserId);
                var device = new Device()
                {
                    Name = model.Device.Name,
                    Description = model.Device.Description,
                    Serialnumber = model.Device.SerialNumber,
                    RegularMaintenance = model.Device.RegularMaintenance,
                    UserId = user.Id,
                    TypeOfDeviceId = model.Device.TypeOfDeviceId,
                    MediumId = model.Device.MediumId
                };

                _deviceService.Add(device);
                return Ok();
            });
        }

        /// <summary>
        /// Updates a device for a specific user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("device")]
        public IHttpActionResult UpdateDeviceForUser(UpdateDeviceBindingModel model)
        {
            return ControllerUtility.Guard(() =>
            {
                var device = _deviceService.GetById(model.DeviceId);

                device.Name = model.Name;
                device.Description = model.Description;
                device.Serialnumber = model.SerialNumber;
                device.RegularMaintenance = model.RegularMaintenance;
                device.TypeOfDeviceId = model.TypeOfDeviceId;
                device.MediumId = model.MediumId;

                _deviceService.Update(device);
                return Ok();
            });
        }


        /// <summary>
        /// Delets a specific device
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("device/{deviceId}")]
        public IHttpActionResult DeleteDevice(int deviceId)
        {
            return ControllerUtility.Guard(() =>
            {
                _deviceService.Delete(deviceId);
                return Ok();
            });
        }

        /// <summary>
        /// Deletes all devices for a specific user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("devices/{userId}")]
        public IHttpActionResult DeleteDevicesByUserId(string userId)
        {
            return ControllerUtility.Guard(() =>
            {
                _deviceService.DeleteAllByUserId(userId);
                return Ok();
            });
        }


        /// <summary>
        /// Get all active (non deleted) devices from a specific user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("devices/{userId}")]
        public IHttpActionResult GetDevicesByUser(string userId)
        {
            return ControllerUtility.Guard(() =>
            {
                IEnumerable<DeviceDTO> devices = _deviceService.GetAllActiveByUserId(userId);
                return Ok(devices);
            });
        }

        /// <summary>
        /// Get all devices (deleted/non deleted) from a specific user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("devices/{userId}/all")]
        public IHttpActionResult GetAllDevicesByUser(string userId)
        {
            return ControllerUtility.Guard(() =>
            {
                IEnumerable<DeviceDTO> devices = _deviceService.GetAllByUserId(userId);
                return Ok(devices);
            });
        }

        /// <summary>
        /// Get all deleted devices from a specific user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("devices/{userId}/deleted")]
        public IHttpActionResult GetAllDeletedDevicesByUser(string userId)
        {
            return ControllerUtility.Guard(() =>
            {
                IEnumerable<DeviceDTO> devices = _deviceService.GetAllDeletedByUserId(userId);
                return Ok(devices);
            });
        }
       
    }
}