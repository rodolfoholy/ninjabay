using Microsoft.AspNetCore.Mvc;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Results;

namespace SenacSp.ProjetoIntegrador.Web.Controllers
{
    public class BaseApiController : Controller
    {
        protected readonly IDomainNotification DomainNotification;

        public BaseApiController(IDomainNotification domainNotification)
        {
            DomainNotification = domainNotification;
        }

        [NonAction]
        public IActionResult CreateResponse()
        {
            if (!DomainNotification.HasNotifications()) return Ok(EnvelopResult.Ok());
            return BadRequest(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult CreateResponse<T>(T data = default(T))
        {
            if (!DomainNotification.HasNotifications()) return Ok(EnvelopDataResult<T>.Ok(data));
            return BadRequest(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult CreatedResponse(string url = "")
        {
            if (!DomainNotification.HasNotifications()) return Created(url, EnvelopResult.Ok());
            return BadRequest(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult CreatedResponse<T>(T data = default(T), string url = "")
        {
            if (!DomainNotification.HasNotifications()) return Created(url, EnvelopDataResult<T>.Ok(data));
            return BadRequest(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult NotFoundResponse()
        {
            if (DomainNotification.HasNotifications())
            {
                DomainNotification.Dispose();
            }

            DomainNotification.Handle(new Notification("Recurso não encontrado"));
            return new NotFoundObjectResult(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult UnprocessableResponse()
        {
            if (DomainNotification.HasNotifications())
            {
                DomainNotification.Dispose();
            }

            DomainNotification.Handle(new Notification("Entidade não processável"));

            return UnprocessableEntity(EnvelopResult.Fail(DomainNotification.Notify()));
        }

        [NonAction]
        public IActionResult UnauthorizedResponse()
        {
            if (DomainNotification.HasNotifications())
            {
                DomainNotification.Dispose();
            }

            DomainNotification.Handle(new Notification("Unauthorized"));

            return new ObjectResult(EnvelopResult.Fail(DomainNotification.Notify()))
            {
                StatusCode = 401
            };
        }

        [NonAction]
        public IActionResult ForbiddenResponse()
        {
            if (DomainNotification.HasNotifications())
            {
                DomainNotification.Dispose();
            }

            DomainNotification.Handle(new Notification("Forbidden"));

            return new ObjectResult(EnvelopResult.Fail(DomainNotification.Notify()))
            {
                StatusCode = 403
            };
        }

        protected override void Dispose(bool disposing)
        {
            DomainNotification.Dispose();
        }
    }
}
