namespace Reviso.TimeSheet.DC.Services.Test.AbpModule
{
    using Abp.Modules;
    using System.Reflection;

    /// <summary>
    /// This module allows the creation of the specific bootstrapper for the current library 
    /// </summary>
    public class DCServicesTestModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
             IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
