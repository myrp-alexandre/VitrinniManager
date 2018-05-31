using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace VitrinniManager.API.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseMessage response;

        public BaseController()
        {
            this.response = new HttpResponseMessage();
        }

        [HttpGet]
        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            response = Request.CreateResponse(code, result);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
