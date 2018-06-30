using FluentAssertions;
using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Core.Services.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Greenfinch.Newsletter.Web.Core.Services.Tests
{
    public class NewsletterSubscriptionServiceTests
    {
        private NewsletterSubscriptionService _newsletterSubscriptionService;
        private Mock<IAsyncRepository<Subscriber>> _subscriperRepositoryMock = new Mock<IAsyncRepository<Subscriber>>();
        private Mock<ILogger<NewsletterSubscriptionService>> loggerMock = new Mock<ILogger<NewsletterSubscriptionService>>();


        public NewsletterSubscriptionServiceTests()
        {
            _newsletterSubscriptionService = new NewsletterSubscriptionService(loggerMock.Object, _subscriperRepositoryMock.Object);
        }


        [Fact]
        public async Task Get_ReturnsSubscriber()
        {
            var guid = new Guid("27929e90-e75a-4e5d-b1fc-dca83137cfaf");
           
            // Arrange
            _subscriperRepositoryMock.Setup(m => m.GetByIdAsync(guid)).Returns(Task.FromResult<Subscriber>(new Subscriber { }));

            // Act
            var result = await _newsletterSubscriptionService.Get(guid);

            // Assert
            result.Should().NotBeNull();
        }

    }
}
