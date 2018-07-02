using FluentAssertions;
using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Models.Enums;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.ISpecifications;
using Greenfinch.Newsletter.Web.Core.Services.Services;
using Greenfinch.Newsletter.Web.Core.Services.Specifications;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Greenfinch.Newsletter.Web.Core.Services.Tests
{
    /// <summary>
    /// Should cover 100% of business logic
    /// </summary>
    public class NewsletterSubscriptionServiceTests
    {
        #region Private Members
        private NewsletterSubscriptionService _newsletterSubscriptionService;
        private Mock<IAsyncRepository<Subscriber>> _subscriperRepositoryMock = new Mock<IAsyncRepository<Subscriber>>();
        private Mock<ILogger<NewsletterSubscriptionService>> loggerMock = new Mock<ILogger<NewsletterSubscriptionService>>();
        #endregion

        #region Ctor
        public NewsletterSubscriptionServiceTests()
        {
            _newsletterSubscriptionService = new NewsletterSubscriptionService(loggerMock.Object, _subscriperRepositoryMock.Object);
        }
        #endregion

        #region Tests
        [Fact]
        public async Task Get_ReturnsNull()
        {
            // Arrange
            _subscriperRepositoryMock.Setup(m => m.ListAllAsync()).Returns(Task.FromResult<List<Subscriber>>(null));

            // Act
            var result = await _newsletterSubscriptionService.Get();

            // Assert
            result.Should().BeNull();
        }


        [Fact]
        public async Task Get_ReturnsList()
        {
            // Arrange
            _subscriperRepositoryMock.Setup(m => m.ListAllAsync()).Returns(Task.FromResult<List<Subscriber>>(new List<Subscriber>() { }));

            // Act
            var result = await _newsletterSubscriptionService.Get();

            // Assert
            result.Should().NotBeNull();
        }

        [Theory, InlineData("user1@test.com"), InlineData("notexistsUser@test.com")]
        public async Task IsEmailExists_ReturnsCorrectBehavior(string expectedEmail)
        {
            // Arrange
            if (expectedEmail.ToLower() == "notexistsUser@test.com".ToLower())
                _subscriperRepositoryMock.Setup(m => m.GetSingleBySpecAsync(It.IsAny<ISpecification<Subscriber>>())).Returns(Task.FromResult<Subscriber>(new Subscriber
                {
                    Email = expectedEmail
                }));
            else
                _subscriperRepositoryMock.Setup(m => m.GetSingleBySpecAsync(It.IsAny<ISpecification<Subscriber>>())).Returns(Task.FromResult<Subscriber>(null));

            // Act
            var result = await _newsletterSubscriptionService.IsEmailExists(expectedEmail);

            // Assert
            if (expectedEmail.ToLower() == "notexistsUser@test.com".ToLower())
                result.Should().BeTrue();
            else
                result.Should().BeFalse();

        }

        [Fact]
        public async Task Add_AddingCorrectly()
        {
            var id = new Guid("7ff91e8f-a92c-431e-a3d7-78843134817f");

            var subscriber = new Subscriber
            {
                Id = id,
                Email = "vvv@email.com",
                HeardFrom = HeardAboutUsFrom.Advert.ToString()
            };
            // Arrange
            _subscriperRepositoryMock.Setup(m => m.AddAsync(subscriber)).Returns(Task.FromResult<Subscriber>(subscriber));

            // Act
            var result = await _newsletterSubscriptionService.Add(subscriber);

            // Assert
            result.Id.Should().Equals(id);
        } 
        #endregion

    }
}
