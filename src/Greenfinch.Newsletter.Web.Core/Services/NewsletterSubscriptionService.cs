using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices;
using Greenfinch.Newsletter.Web.Core.Services.Specifications;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Services
{
    /// <summary>
    /// Concrete implementation of INewsletterSubscriptionService
    /// </summary>
    public class NewsletterSubscriptionService : INewsletterSubscriptionService
    {

        #region Private Members
        private readonly ILogger _logger;
        private readonly IAsyncRepository<Subscriber> _subscriberRepository;
        #endregion

        #region Ctor
        public NewsletterSubscriptionService(ILogger<NewsletterSubscriptionService> logger, IAsyncRepository<Subscriber> subscriberRepository)
        {
            _logger = logger;
            _subscriberRepository = subscriberRepository;
        }
        #endregion
        
        #region Public Methods

        public async Task<List<Subscriber>> Get()
        {
            return await _subscriberRepository.ListAllAsync();
        }

        public async Task<bool> IsEmailExists(string email)
        {
            return await _subscriberRepository.GetSingleBySpecAsync(new SubscriberSpecification(email)) != null ? true : false;

        }

        public Task<Subscriber> Add(Subscriber subscriber)
        {
            _logger.LogInformation("Sample of using log");
            return _subscriberRepository.AddAsync(subscriber);

        }

        #endregion
    }
}
