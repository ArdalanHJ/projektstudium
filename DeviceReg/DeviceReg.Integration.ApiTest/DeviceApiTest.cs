using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Integration.ApiTest
{
    [TestFixture]
    public class DeviceApiTest:AbstractApiTest
    {
        [Test]
        public void TestGetDeviceById()
        {
            
            var request = GetRequest("/Device/GetDeviceById");

            //TODO : you should add paramter for request
            //request.AddBody();

            var response = RestClient.Execute(request);

            //check response and 
            Assert.AreEqual("", response);
        }
    }
}
