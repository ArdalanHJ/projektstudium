using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Integration.ApiTest
{
    public class AbstractApiTest
    {
        protected string ServerUrl { get { return "https://www.devRegProject.com"; } }

        RestClient _RestClient;
        protected RestClient RestClient { get { return _RestClient; } }

        public AbstractApiTest()
        {
            _RestClient = new RestClient(ServerUrl);
        }


        protected RestRequest GetRequest(string resource)
        {
            var request = new RestRequest(resource);

            request.Method = Method.GET;
            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;

            return request;
        }
    }
}
