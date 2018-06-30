using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Services
{
    public class NewsletterSubscriptionService : INewsletterSubscriptionService
    {

        private readonly ILogger _logger;
        private readonly IAsyncRepository<Subscriber> _subscriberRepository;


        public NewsletterSubscriptionService(ILogger<NewsletterSubscriptionService> logger, IAsyncRepository<Subscriber> subscriberRepository)
        {
            _logger = logger;
            _subscriberRepository = subscriberRepository;
        }

        public Task<Subscriber> Get(Guid id)
        {
            return _subscriberRepository.GetByIdAsync(id);
        }

        public Task<Subscriber> Add(Subscriber subscriber)
        {
            _logger.LogInformation("test");
            return _subscriberRepository.AddAsync(subscriber);
        }





    }
}
