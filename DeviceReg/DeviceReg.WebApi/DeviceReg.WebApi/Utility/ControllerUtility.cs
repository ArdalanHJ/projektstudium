using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DeviceReg.WebApi.Utility
{
    public class ControllerUtility
    {
        public static HttpResponseMessage Guard(Func<HttpResponseMessage> function)
        {
            var returncode = HttpStatusCode.BadRequest;
            try
            {
                return function();
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