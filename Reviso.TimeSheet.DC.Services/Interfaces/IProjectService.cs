using Abp.Application.Services;
using Reviso.TimeSheet.Entities;
using Reviso.TimeSheet.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Reviso.TimeSheet.DC.Services.Interfaces
{
    public interface IProjectService : IApplicationService
    {
        ICollection<ProjectViewModel> GetAll();

        void Edit(ProjectViewModel viewModel);

        ProjectViewModel Add(ProjectViewModel viewModel);

        void Delete(ProjectViewModel viewModel);
    }
}
