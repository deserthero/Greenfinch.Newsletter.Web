using Greenfinch.Newsletter.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices
{
    public interface INewsletterSubscriptionService
    {
        Task<Subscriber> Add(Subscriber subscriber);
    }
}
