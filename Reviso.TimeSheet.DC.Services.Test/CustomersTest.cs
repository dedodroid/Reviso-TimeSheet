using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reviso.TimeSheet.DC.Services.Interfaces;
using System.Linq;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.Repositories.Repository;
using Abp.Dependency;

namespace Reviso.TimeSheet.DC.Services.Test
{
    [TestClass]
    public class CustomersTest : BaseBootstrapperUnitTest
    {

        [TestInitialize]
        public void Initialize()
        {
            base.Configure();
        }

        [TestCleanup]
        public void Shutdown()
        {
            base.CleanUp();
        }

        [TestMethod]
        public void GetAllCustomers()
        {
            ICustomerService customerService = GetBootstrapper().IocManager.Resolve<ICustomerService>();

            var customers = customerService.GetAll();

            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count() > 0, "There are some customers");
        }
    }
}
