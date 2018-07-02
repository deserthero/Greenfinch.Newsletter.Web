using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Infrastructure.FakeEmailService
{
    /// <summary>
    /// For Example SMTP Client Implementation
    /// </summary>
    public class AnotherFakeEmailService : IEmailService
    {

        public Task SendAsync(string message, string messageInHtmlFormat, string subject, List<string> toList, string senderEmail, bool isBcc)
        {
            // Another Emailing Service Implementation 
            // Email Has Been Sent
            return Task.FromResult<object>(null);
        }
    }
}
