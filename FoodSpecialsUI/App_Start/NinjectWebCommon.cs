[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FoodSpecialsUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FoodSpecialsUI.App_Start.NinjectWebCommon), "Stop")]

namespace FoodSpecialsUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repository;
    using Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Ninject.Parameters;
    using Authorization;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<UserManager<AppUser>>().ToMethod(context => Startup.UserManagerFactory());

            //kernel.Bind<IRestaurantRepository>().To<RestaurantRepository>();
            kernel.Bind<IFoodSpecialRepository>().To<FoodSpecialRepository>();

            //kernel.Bind<IRestaurantService>().To<RestaurantService>();
            kernel.Bind<IFoodSpecialService>().To<FoodSpecialService>();
            kernel.Bind<IYelpAPIService>().To<YelpAPIService>();
            kernel.Bind<IAuthService>().To<AuthService>();
        }        
    }
}
