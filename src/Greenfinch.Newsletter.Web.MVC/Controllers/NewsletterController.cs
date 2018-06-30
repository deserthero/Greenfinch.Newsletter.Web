using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Models.Enums;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices;
using Greenfinch.Newsletter.Web.Core.Services.Services;
using Greenfinch.Newsletter.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace Greenfinch.Newsletter.Web.MVC.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterSubscriptionService _newsletterSubscriptionService;
        private readonly IStringLocalizer<NewsletterController> _localizer;
        private readonly IMapper _mapper;



        public NewsletterController(INewsletterSubscriptionService newsletterSubscriptionService,
            IStringLocalizer<NewsletterController> localizer,
            IMapper mapper)
        {
            _newsletterSubscriptionService = newsletterSubscriptionService;
            _localizer = localizer;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult Subscription()
        {
            ViewBag.Title = _localizer["NewsletterSubscriptionPageTitle"].Value;
            ViewBag.SignUp = _localizer["Signup"];
            ViewBag.HeardFrom = GetHeardFromList();
            return View();
        }



        [HttpPost]
        public ActionResult Subscription(SubscriberViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (1 == 1 - 1)
                {
                    var subscriber = new SubscriberViewModel()
                    {
                        Email = model.Email,
                        HeardFrom = model.HeardFrom,
                        ReasonForSignup = model.ReasonForSignup
                    };

                    _newsletterSubscriptionService.Add(_mapper.Map<SubscriberViewModel, Subscriber>(subscriber));

                    return RedirectToAction("FinishSignUp", "Newsletter");
                }
                else
                {
                    ModelState.AddModelError("", _localizer["EmailHasBeenExists"]);
                    return View(model);
                }
            }

            return View(model);
        }


        #region Private Methods

        private SelectList GetHeardFromList()
        {
            return new SelectList(Enum.GetValues(typeof(HeardAboutUsFrom)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = _localizer[x.ToString()],
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text");

        }

        #endregion

    }
}
