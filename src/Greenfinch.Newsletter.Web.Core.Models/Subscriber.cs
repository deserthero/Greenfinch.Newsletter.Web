using System;

namespace Greenfinch.Newsletter.Web.Core.Models
{
    /// <summary>
    /// Subscriber POCO Class 
    /// </summary>
    public class Subscriber : BaseEntity
    {
        public string Email { get; set; }
        public string HeardFrom { get; set; }
        public string ReasonForSignup { get; set; }
    }

}
