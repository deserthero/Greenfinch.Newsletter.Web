using System;

namespace Greenfinch.Newsletter.Web.Core.Models
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HeardFrom { get; set; }
        public string ReasonForSignup { get; set; }
    }
}
