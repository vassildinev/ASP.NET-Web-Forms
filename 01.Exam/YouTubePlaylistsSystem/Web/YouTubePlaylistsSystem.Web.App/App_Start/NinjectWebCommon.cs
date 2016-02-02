[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YouTubePlaylistsSystem.Web.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(YouTubePlaylistsSystem.Web.App.App_Start.NinjectWebCommon), "Stop")]

namespace YouTubePlaylistsSystem.Web.App.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Common.Constants;
    using Data;
    using Data.Repositories.Contracts;
    using Data.Repositories;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel
                .Bind<IYouTubePlaylistsSystemDbContext>()
                .To<YouTubePlaylistsSystemDbContext>()
                .InRequestScope();

            kernel
                .Bind(typeof(IRepository<>))
                .To(typeof(GenericRepository<>));
        };

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
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
        
        private static void RegisterServices(IKernel kernel)
        {
            DependenciesRegistration(kernel);
            kernel.Bind(b => b
                .From(Assemblies.Services)
                .SelectAllClasses()
                .BindDefaultInterface());
        }        
    }
}
