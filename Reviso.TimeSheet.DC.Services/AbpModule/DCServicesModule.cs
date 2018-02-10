namespace Reviso.TimeSheet.DC.Services.AbpModule
{
    using Abp.Modules;
    using System.Reflection;

    [DependsOn(typeof(RepositoriesModule))]
    public class DCServicesModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //IocManager.Register<ICustomerRepository,  CustomerRepository>(DependencyLifeStyle.Transient);
            //IocManager.Register<IProjectRepository, ProjectRepository>(DependencyLifeStyle.Transient);
            //IocManager.Register<ITimeSheetRepository, TimeSheetRepository>(DependencyLifeStyle.Transient);
            //base.Initialize();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
