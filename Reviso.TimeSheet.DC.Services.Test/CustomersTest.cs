using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reviso.TimeSheet.DC.Services.Interfaces;
using System.Linq;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.Repositories.Repository;

namespace Reviso.TimeSheet.DC.Services.Test
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAllCustomers()
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());

            var customers = customerService.GetAll();

            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count() > 0, "There are some customers");
        }
    }
}
