using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures
{
    /// <summary>
    /// Allow user to add diffrent implementations like SendGrid, SMTP and etc.
    /// </summary>
    public interface IEmailService
    {
        Task SendAsync(string message, string messageInHtmlFormat, string subject, List<string> toList, string senderEmail, bool isBcc);

    }
}
