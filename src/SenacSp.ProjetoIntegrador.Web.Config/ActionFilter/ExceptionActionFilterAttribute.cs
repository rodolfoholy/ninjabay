using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SenacSp.ProjetoIntegrador.Logging;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Results;

namespace SenacSp.ProjetoIntegrador.Web.Config.ActionFilter
{
    public class ExceptionActionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var notification = new Notification("Ocorreu um erro interno");

            var domainNotification =
                context.HttpContext.RequestServices.GetService(typeof(IDomainNotification)) as IDomainNotification;

            AppLoggerFactory.GetLogger().Error(context.Exception);

            if (domainNotification == null)
            {
                context.Result = new ObjectResult(EnvelopResult.Fail(new[] { notification }))
                {
                    StatusCode = 500
                };
                return;
            }

            if (!domainNotification.HasNotifications())
            {
                domainNotification.Handle(notification);
            }

            context.Result = new ObjectResult(EnvelopResult.Fail(domainNotification.Notifications))
            {
                StatusCode = 500
            };
        }
    }
}
