using DeviceReg.WebApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceReg.WebApi.Controllers
{
    /// <summary>
    /// Controller for Support
    /// </summary>
    [Authorize(Roles = "Support")]
    [RoutePrefix("api/support")]
    public class SupportController : ApiControllerBase
    {

    }
}