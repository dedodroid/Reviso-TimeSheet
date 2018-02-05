using Abp;
using Abp.Owin;
using Castle.Windsor;
using Giuffre.Teseo.Api.Suggest;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using Reviso.TimeSheet.Repositories;
using Reviso.TimeSheet.WebApi.WindsorAdapters;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;

[assembly: OwinStartup(typeof(Reviso.TimeSheet.WebApi.Startup))]

namespace Reviso.TimeSheet.WebApi
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            httpConfig.EnableCors();

            AbpBootstrapper bootstrapper = ConfigureCoreServices(app, httpConfig);

            ConfigureOAuth(app);

            ConfigureWebApi(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);

            Database.SetInitializer(new Initializer());

        }

        private AbpBootstrapper ConfigureCoreServices(IAppBuilder app, HttpConfiguration config)
        {
            app.UseAbp();

            // Create of bootstrapper giving to it the application module
            AbpBootstrapper bootstrapper = AbpBootstrapper.Create<TimeSheetApiModule>();

            // Init of Abp library
            bootstrapper.Initialize();

            // Registration of specific services of the web application,
            // to leave the below library free from constraints
            IWindsorContainer container = bootstrapper.IocManager.IocContainer;

            container.Install(new WebWindsorInstaller());

            // Last operation, replacing default Controller Activation
            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));

            return bootstrapper;
        }

        /// <summary>
        /// WebApi configuration and set of JSON serializer camelCase type 
        /// </summary>
        /// <param name="config">httpConfig</param>
        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new Newtonsoft.Json.Converters.StringEnumConverter());
        }
    }
}