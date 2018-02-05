using Abp.Application.Services;
using Reviso.TimeSheet.Entities;
using Reviso.TimeSheet.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Reviso.TimeSheet.DC.Services.Interfaces
{
    public interface ICustomerService : IApplicationService
    {
        ICollection<CustomerViewModel> GetAll();

        CustomerViewModel GetSingle(int id);

        void Edit(CustomerViewModel viewModel);

        CustomerViewModel Add(CustomerViewModel viewModel);

        void Delete(CustomerViewModel viewModel);
    }
}
