using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Linx.Web.App_Start
{
    public class WebApplicationAccessController : ApiController
    {

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] string applicationName)
        {
            var webApplication = WebApplicationAccess.GrantApplication(applicationName);
            return Ok<WebApplicationAccess>(webApplication);
        }


    }
}