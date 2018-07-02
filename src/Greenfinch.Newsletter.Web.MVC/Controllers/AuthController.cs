using System.Threading.Tasks;
using Greenfinch.Newsletter.Web.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Greenfinch.Newsletter.Web.MVC.Controllers
{
    /// <summary>
    /// AuthController to provide login and logout fetures
    /// </summary>
    [Authorize]
    public class AuthController : Controller
    {

        #region Private Members
        private SignInManager<IdentityUser> _signInManager;
        #endregion

        #region Ctor
        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        } 
        #endregion

        #region Public Actions

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userByEmail = await _signInManager.UserManager.FindByEmailAsync(model.Email);

            if (!string.IsNullOrEmpty(model.Email) && userByEmail != null)
            {
                var result = await _signInManager.PasswordSignInAsync(userByEmail.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Email Not Found.");
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        } 
        #endregion

    }
}