using System.Linq;
using Reviso.TimeSheet.Entities;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.Repositories;
using Reviso.TimeSheet.Repositories.Repository;
using Abp.Application.Services;
using Reviso.TimeSheet.ViewModels;
using System;
using Reviso.TimeSheet.DC.Services.Interfaces;
using System.Collections.Generic;

namespace Reviso.TimeSheet.DC.Services
{
    public class CustomerService : ApplicationService, ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ICollection<CustomerViewModel> GetAll()
        {
            var customerViewModelList = new List<CustomerViewModel>();

            foreach(var customer in _repository.GetAll())
            {
                customerViewModelList.Add(new CustomerViewModel(customer));
            }

            return customerViewModelList;
        }

        public CustomerViewModel GetSingle(int id)
        {
            var model = _repository.GetSingle(id);
            return new CustomerViewModel(model);
        }

        public void Edit(CustomerViewModel viewModel)
        {
            _repository.Edit(viewModel.ToCustomerEntity());
            _repository.Save();
        }

        public CustomerViewModel Add(CustomerViewModel viewModel)
        {
            var model = _repository.Add(viewModel.ToCustomerEntity());
            _repository.Save();
            return new CustomerViewModel(model);
        }

        public void Delete(CustomerViewModel viewModel)
        {
            _repository.Delete(viewModel.ToCustomerEntity());
            _repository.Save();
        }
    }
}
