using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NinjaBay.Logging;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Results;
using NinjaBay.Shared.Utils;

namespace NinjaBay.Web.Config.ActionFilter
{
    public static class ErrorHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is InvalidOperationException &&
                            contextFeature.Error.Message.StartsWith(
                                "The SPA default page middleware could not return the default page"))
                            return;

                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                        EnvelopResult result = null;

                        var notification = new Notification("Ocorreu um erro interno");

                        var domainNotification =
                            context.RequestServices.GetService(typeof(IDomainNotification)) as IDomainNotification;

                        AppLoggerFactory.GetLogger().Error(contextFeature.Error);

                        if (domainNotification == null) result = EnvelopResult.Fail(new[] {notification});

                        if (domainNotification?.HasNotifications() == false)
                        {
                            domainNotification.Handle(notification);
                            result = EnvelopResult.Fail(domainNotification?.Notifications);
                        }

                        var response = JsonUtils.Serialize(result);

                        await context.Response.WriteAsync(response);
                    }
                });
            });
        }
    }
}