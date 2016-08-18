using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ReplyTest.Http;

namespace ReplyTest.Controllers
{
    [RoutePrefix("api")]
    public class AppsController : ApiController
    {
        private MattersHttpClient _client;

        public AppsController()
        {
            _client = new MattersHttpClient();
        }

        [HttpGet, Route("top")]
        public async Task<HttpResponseMessage> GetTopAppsAsync(HttpRequestMessage request)
        {
            var response = await _client.GetTopRatedAppsAsync(15);

            return request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
