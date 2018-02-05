using Abp.Application.Services;
using Reviso.TimeSheet.Entities;
using Reviso.TimeSheet.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Reviso.TimeSheet.DC.Services.Interfaces
{
    public interface ITimeSheetService : IApplicationService
    {
        ICollection<TimeSheetViewModel> GetAll();

        TimeSheetViewModel GetSingle(int id);

        void Edit(TimeSheetViewModel viewModel);

        TimeSheetViewModel Add(TimeSheetViewModel viewModel);

        void Delete(TimeSheetViewModel viewModel);
    }
}
