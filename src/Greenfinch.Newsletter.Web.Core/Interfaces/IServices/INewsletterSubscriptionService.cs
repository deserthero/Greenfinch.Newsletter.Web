using Greenfinch.Newsletter.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices
{
    /// <summary>
    /// NewsletterSubscriptionService specific features
    /// </summary>
    public interface INewsletterSubscriptionService
    {
        Task<List<Subscriber>> Get();

        Task<bool> IsEmailExists(string email);

        Task<Subscriber> Add(Subscriber subscriber);
    }
}
