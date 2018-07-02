using Greenfinch.Newsletter.Web.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.MVC.ViewModels
{
    /// <summary>
    /// SubscriberViewModel
    /// </summary>
    public class SubscriberViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.ViewModels.Subscriber), ErrorMessageResourceName = "EmailRequied")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ViewModels.Subscriber), ErrorMessageResourceName = "EmailNotValid")]
        [Display(ResourceType = typeof(Resources.ViewModels.Subscriber) , Name = "Email")]
        public string Email { get; set; }


        [Display(ResourceType = typeof(Resources.ViewModels.Subscriber), Name = "HearAboutUs")]
        public HeardAboutUsFrom HeardFrom { get; set; }


        [Display(ResourceType = typeof(Resources.ViewModels.Subscriber), Name = "ReasonForSignup")]
        public string ReasonForSignup { get; set; }
    }
}
