using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.MVC.ViewModels
{
    public class SubscriberViewModel
    {
        public string Email { get; set; }
        public string HeardFrom { get; set; }
        public string ReasonForSignup { get; set; }
    }
}
