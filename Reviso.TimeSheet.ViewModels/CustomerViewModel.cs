using Reviso.TimeSheet.Entities;
using System;

namespace Reviso.TimeSheet.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public CustomerViewModel()
        {
        }

        public CustomerViewModel(CustomerEntity customer)
        {
            if (customer == null)
            {
                return;
            }

            CustomerId = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Address = customer.Address;
            Email = customer.Email;
        }

        public CustomerEntity ToCustomerEntity()
        {
            return new CustomerEntity
            {
                Id = CustomerId,
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                Email = Email
            };
        }
    }
}