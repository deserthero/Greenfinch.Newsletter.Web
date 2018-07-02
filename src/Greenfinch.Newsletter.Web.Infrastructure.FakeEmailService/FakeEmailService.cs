using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Infrastructure.FakeEmailService
{
    /// <summary>
    /// For Example SendGrid service implementation
    /// </summary>
    public class FakeEmailService : IEmailService
    {

        public Task SendAsync(string message, string messageInHtmlFormat, string subject, List<string> toList, string senderEmail, bool isBcc)
        {
            // Emailing Service Implementation 

            // Email Has Been Sent
            return Task.FromResult<object>(null);
        }
    }
}
