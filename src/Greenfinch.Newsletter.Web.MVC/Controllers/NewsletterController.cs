using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Greenfinch.Newsletter.Web.Common.Interfaces;
using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Models.Enums;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IServices;
using Greenfinch.Newsletter.Web.Core.Services.Services;
using Greenfinch.Newsletter.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Protocols;

namespace Greenfinch.Newsletter.Web.MVC.Controllers
{
    /// <summary>
    /// NewsLetter MVC Controller
    /// </summary>
    public class NewsletterController : Controller
    {
        #region Private Members
        private readonly IEmailService _emailService;
        private readonly INewsletterSubscriptionService _newsletterSubscriptionService;
        private readonly IStringLocalizer<NewsletterController> _localizer;
        private readonly IMapper _mapper;
        private readonly IAppConfigManager _configurationManager;

        #endregion

        #region Ctor
        public NewsletterController(INewsletterSubscriptionService newsletterSubscriptionService, IEmailService emailService,
           IStringLocalizer<NewsletterController> localizer,
           IMapper mapper, IAppConfigManager configurationManager)
        {
            _emailService = emailService;
            _newsletterSubscriptionService = newsletterSubscriptionService;
            _localizer = localizer;
            _mapper = mapper;
            _configurationManager = configurationManager;
        }
        #endregion

        #region Public Actions
        [HttpGet]
        public ActionResult Subscription()
        {
            ViewBag.HeardFrom = GetHeardFromList();
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Subscription(SubscriberViewModel model)
        {
            ViewBag.HeardFrom = GetHeardFromList();

            if (ModelState.IsValid)
            {
                if (!await _newsletterSubscriptionService.IsEmailExists(model.Email))
                {
                    await _newsletterSubscriptionService.Add(_mapper.Map<SubscriberViewModel, Subscriber>(new SubscriberViewModel()
                    {
                        Email = model.Email,
                        HeardFrom = model.HeardFrom,
                        ReasonForSignup = model.ReasonForSignup
                    }));

                    return RedirectToAction("SubscriptionSuccess", "Newsletter", new { email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("", _localizer["EmailHasBeenExists"]);
                    return View(model);
                }
            }

            return View(model);
        }



        [HttpGet]
        public async Task<ActionResult> SubscriptionSuccess([FromQuery(Name = "email")] string subscriberEmail)
        {

            string sendTo, msg, subject, senderEmail;

            BuildEmailMetaData(subscriberEmail, out sendTo, out msg, out subject, out senderEmail);

            if (!string.IsNullOrEmpty(sendTo) && !string.IsNullOrEmpty(senderEmail))
            {
                ViewBag.SendTo = sendTo;
                await _emailService.SendAsync(msg, string.Empty, subject, new List<string> { sendTo }, senderEmail, false);
            }

            return View();
        }





        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> SubscribersList()
        {
            var list = await _newsletterSubscriptionService.Get();

            if (list != null)
                return View(_mapper.Map<List<Subscriber>, List<SubscriberViewModel>>(list));
            else
                return View(new List<SubscriberViewModel>());
        } 
        #endregion

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

        private void BuildEmailMetaData(string subscriberEmail, out string sendTo, out string msg, out string subject, out string senderEmail)
        {
            sendTo = subscriberEmail ?? string.Empty;
            msg = _configurationManager.GetAppSettingsValueOrDefault<string>("WelcomeEmailMsg", string.Empty);
            subject = _configurationManager.GetAppSettingsValueOrDefault<string>("WelcomeEmailSubject", string.Empty);
            senderEmail = _configurationManager.GetAppSettingsValueOrDefault<string>("SenderMail", string.Empty);
        }


        #endregion

    }
}
