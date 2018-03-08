using FoodSpecialsUI.Models;
using FoodSpecialsUI.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpecialsUI.Services
{
    [ContractClass(typeof(IAuthServiceContract))]
    public interface IAuthService
    {
        /// <summary>
        /// Returns the viewmodel for the login page
        /// </summary>
        /// <param name="returnUrl">The return url if the user was previously on a page</param>
        /// <returns>Login view model</returns>
        LoginViewModel GetLoginViewModel(string returnUrl);

        /// <summary>
        /// Signs the user into the session. Returns a bool on whether the user was found and signed in
        /// </summary>
        /// <param name="viewModel">The login in view model</param>
        /// <returns>Whether the user is signed in</returns>
        bool SignInUser(LoginViewModel viewModel);

        /// <summary>
        /// Logs a user out of current session
        /// </summary>
        void LogOut();

        /// <summary>
        /// Creates a new user, automatically adds to user role
        /// </summary>
        /// <param name="viewModel">The register view mdoel</param>
        /// <returns>The result of registering a new user</returns>
        IdentityResult Register(RegisterViewModel viewModel);

        /// <summary>
        /// Gets an app user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AppUser GetAppUser(string id);
    }

    #region Contracts classes
    [ContractClassFor(typeof(IAuthService))]
    abstract class IAuthServiceContract : IAuthService
    {
        public LoginViewModel GetLoginViewModel(string returnUrl)
        {
            throw new NotImplementedException();
        }

        public bool SignInUser(LoginViewModel viewModel)
        {
            Contract.Requires(viewModel != null);
            throw new NotImplementedException();
        }
        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public IdentityResult Register(RegisterViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public AppUser GetAppUser(string id)
        {
            Contract.Requires(!string.IsNullOrEmpty(id));
            throw new NotImplementedException();
        }
    }
    #endregion
}
