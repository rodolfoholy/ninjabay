using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Shared.Notifications;

namespace SenacSp.ProjetoIntegrador.Web.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/tests")]
    public class TestsController : BaseApiController
    {
        public TestsController(IDomainNotification domainNotification) : base(domainNotification)
        {
        }
        [HttpGet]
        public IActionResult Get() => Ok("teste123");
    }
}
