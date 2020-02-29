using SenacSp.ProjetoIntegrador.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class BaseQueryHandler
    {
        protected IDomainNotification Notifications;

        public BaseQueryHandler(IDomainNotification notifications)
        {
            Notifications = notifications;
        }
    }
}