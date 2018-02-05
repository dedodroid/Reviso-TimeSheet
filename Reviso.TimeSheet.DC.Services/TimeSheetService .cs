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
    public class TimeSheetService : ApplicationService, ITimeSheetService
    {
        private readonly ITimeSheetRepository _repository;

        public TimeSheetService(ITimeSheetRepository repository)
        {
            _repository = repository;
        }

        public ICollection<TimeSheetViewModel> GetAll()
        {
            var timeSheetList = _repository.GetAll();
            var timeSheetViewModelList = new List<TimeSheetViewModel>();

            foreach(var record in timeSheetList)
            {
                timeSheetViewModelList.Add(new TimeSheetViewModel(record));
            }

            return timeSheetViewModelList;

        }

        public TimeSheetViewModel GetSingle(int id)
        {
            var model = _repository.GetSingle(id);
            return new TimeSheetViewModel(model);
        }

        public void Edit(TimeSheetViewModel viewModel)
        {
            _repository.Edit(viewModel.ToTimeSheetEntity());
            _repository.Save();
        }

        public TimeSheetViewModel Add(TimeSheetViewModel viewModel)
        {
            var model = _repository.Add(viewModel.ToTimeSheetEntity());
            _repository.Save();
            return new TimeSheetViewModel(model);
        }

        public void Delete(TimeSheetViewModel viewModel)
        {
            _repository.Delete(viewModel.ToTimeSheetEntity());
            _repository.Save();
        }
    }
}
