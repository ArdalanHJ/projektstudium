using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.WebApi.Models.DTOs;
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
    [Authorize(Roles = "admin")]
    [RoutePrefix("api/admin")]
    public class AdminController: ApiControllerBase
    {
        private UserService _userService;
        private DeviceService _deviceService;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            _userService = new UserService(UnitOfWork);
            _deviceService = new DeviceService(UnitOfWork);

        }

        [HttpPost]
        [Route("devices")]
        public HttpResponseMessage GetDevicesByUser(UserIdBindingModel model)
        {
            IEnumerable<DeviceDTO> devices = _deviceService.GetDevicesByUser(model.UserId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, devices);
            return response;
        }
    }
}