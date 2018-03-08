using FoodSpecialsUI.Constants;
using FoodSpecialsUI.Models;
using FoodSpecialsUI.Services;
using FoodSpecialsUI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodSpecialsUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private Lazy<IAuthService> lazyAuthService;

        public AuthController(Lazy<IAuthService> lazyAuthService)
        {
            this.lazyAuthService = lazyAuthService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var viewModel = lazyAuthService.Value.GetLoginViewModel(returnUrl);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (lazyAuthService.Value.SignInUser(model))
            {
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public ActionResult LogOut()
        {
            lazyAuthService.Value.LogOut();
            return RedirectToAction("index", "home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        [Authorize(Roles = AuthConstants.Admin)]
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [Authorize(Roles = AuthConstants.Admin)]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new RegisterViewModel());
            }

            var result = lazyAuthService.Value.Register(model);

            if (result.Succeeded)
            {                          
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }
    }


}