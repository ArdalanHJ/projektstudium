using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.WebApi.Models.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
        private ApplicationUserManager _userManager;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            _userService = new UserService(UnitOfWork);
            _deviceService = new DeviceService(UnitOfWork);

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Route("devices")]
        public HttpResponseMessage GetDevicesByUser(UserIdBindingModel model)
        {
            var returncode = HttpStatusCode.BadRequest;
            try
            {
                IEnumerable<DeviceDTO> devices = _deviceService.GetDevicesByUser(model.UserId);
                return Request.CreateResponse(HttpStatusCode.OK, devices); ;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(returncode)
                {
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(response);
            }
        }

    }
}