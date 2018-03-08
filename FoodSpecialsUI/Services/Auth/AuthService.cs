using FoodSpecialsUI.Models;
using FoodSpecialsUI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using System.Threading.Tasks;
using FoodSpecialsUI.Constants;

namespace FoodSpecialsUI.Services
{
    public class AuthService : IAuthService
    {
        #region Constructor
        private UserManager<AppUser> userManager;

        public AuthService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        #endregion

        #region Public Methods
        public LoginViewModel GetLoginViewModel(string returnUrl)
        {
            return new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
        }

        public bool SignInUser(LoginViewModel viewModel)
        {
            var user = userManager.Find(viewModel.Email, viewModel.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return true;
            }

            return false;
        }

        public void LogOut()
        {
            var authManager = GetAuthenticationManager();

            authManager.SignOut("ApplicationCookie");
        }

        public IdentityResult Register(RegisterViewModel viewModel)
        {
            var user = new AppUser
            {
                UserName = viewModel.Email
            };

            var result = userManager.Create(user, viewModel.Password);

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, AuthConstants.User);
                SignIn(user);
            }

            return result;
        }

        public AppUser GetAppUser(string id)
        {
            return userManager.Users.First(x => x.Id == id);
        }       
        #endregion 

        #region Private Methods
        /// <summary>
        /// Gets the authenication manager
        /// </summary>
        /// <returns></returns>
        private IAuthenticationManager GetAuthenticationManager()
        {
            return HttpContext.Current.GetOwinContext().Authentication;
        }

        /// <summary>
        /// Signs the user in using application cookie
        /// </summary>
        /// <param name="user">The app user</param>
        private void SignIn(AppUser user)
        {
            var identity = userManager.CreateIdentity(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(identity);
        }
        #endregion
    }
}