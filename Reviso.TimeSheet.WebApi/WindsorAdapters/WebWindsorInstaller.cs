using Abp.Application.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Reviso.TimeSheet.DC.Services;
using Reviso.TimeSheet.Repositories.Repository;
using Reviso.TimeSheet.WebApi.Controllers;

namespace Reviso.TimeSheet.WebApi.WindsorAdapters
{
    /// <summary>
    ///  This classe able IoC to load the application services, controllers API and repositories
    /// </summary>
    public class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // ApplicationService Registration
            container.Register(Classes
                .FromAssemblyContaining<CustomerService>()
                .BasedOn<IApplicationService>()
                .LifestylePerWebRequest()
                .WithServiceAllInterfaces());

            // Repositories Registration
            container.Register(Classes
                .FromAssemblyContaining<CustomerRepository>()
                .BasedOn<IApplicationService>()
                .LifestylePerWebRequest()
                .WithServiceAllInterfaces());

            // Controller WebApi Registration
            container.Register(Classes
                .FromAssemblyContaining<CustomerController>()
                .BasedOn<IController>()
                .LifestylePerWebRequest());
        }
    }
}