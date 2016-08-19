using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ReplyTest.Http;
using ReplyTest.Services;

namespace ReplyTest.Controllers
{
    [RoutePrefix("api/apps")]
    public class AppsController : ApiController
    {
        private readonly IAppsService _appsService;

        public AppsController(IAppsService appsService)
        {
            _appsService = appsService;
        }

        [HttpGet, Route("top")]
        public async Task<HttpResponseMessage> GetTopAppsAsync(HttpRequestMessage request)
        {
            var response = await _appsService.GetTopRatedApps(15);

            return request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet, Route("search")]
        public async Task<HttpResponseMessage> SearchAsync(HttpRequestMessage request, string searchPattern)
        {
            return request.CreateResponse(HttpStatusCode.OK, await _appsService.SearchAppsAsync(searchPattern, 25));
        }


        [HttpGet, Route("")]
        public async Task<HttpResponseMessage> GetAppAsync(HttpRequestMessage request, string packageId)
        {
            return request.CreateResponse(HttpStatusCode.OK, await _appsService.GetByPackageIdAsync(packageId));
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAsync(HttpRequestMessage request, int page, int itemsCount)
        {
            if (page <= 0)
                return request.CreateResponse(HttpStatusCode.OK, _appsService.GetAllAsync(page, 0));

            return request.CreateResponse(HttpStatusCode.OK, _appsService.GetAllAsync(page, itemsCount));
        }
    }
}
