using Greenfinch.Newsletter.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices
{
    public interface INewsletterSubscriptionService
    {
        List<Subscriber> Get();
        Subscriber Get(Guid id);
        Subscriber Create(Subscriber subscriber);
        Subscriber Update(Subscriber subscriber);
        void Delete(Guid id);
    }
}
