using Greenfinch.Newsletter.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Specifications
{
    /// <summary>
    /// Spec to retive user by email
    /// </summary>
    public class SubscriberSpecification : BaseSpecification<Subscriber>
    {
        public SubscriberSpecification(string email)
            : base(i => (!string.IsNullOrEmpty(email) && i.Email == email))
        {
        }
    }
}
