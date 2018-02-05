using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reviso.TimeSheet.DC.Services.Interfaces;
using System.Linq;

namespace Reviso.TimeSheet.DC.Services.Test
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAllCustomers()
        {
            ICustomerService customerService = new CustomerService();
            var customers = customerService.GetAll();

            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count() > 0, "There are some customers");
        }
    }
}
