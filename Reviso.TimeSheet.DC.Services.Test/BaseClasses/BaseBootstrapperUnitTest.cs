namespace Reviso.TimeSheet.DC.Services.Test
{
    using Abp;
    using Services.AbpModule;

    /// <summary>
    /// This class allows to instantiate and init the IoC container
    /// </summary>
    public abstract class BaseBootstrapperUnitTest : BaseUnitTest
    {
        private AbpBootstrapper _bootstrapper;

        protected void Configure()
        {
            if(_bootstrapper == null)
            {
                _bootstrapper = AbpBootstrapper.Create<DCServicesModule>();
                _bootstrapper.Initialize();
            }
        }

        protected void CleanUp()
        {
            if (_bootstrapper != null)
            {
                _bootstrapper.Dispose();
                _bootstrapper = null;
            }
        }

        protected AbpBootstrapper GetBootstrapper()
        {
            return _bootstrapper;
        }
    }
}
