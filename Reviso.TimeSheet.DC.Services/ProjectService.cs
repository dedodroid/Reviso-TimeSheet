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
    public class ProjectService : ApplicationService, IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ProjectViewModel> GetAll()
        {
            var projectList = _repository.GetAll();
            var projectViewModelList = new List<ProjectViewModel>();

            foreach(var project in projectList)
            {
                projectViewModelList.Add(new ProjectViewModel(project));
            }

            return projectViewModelList;
        }

        public void Edit(ProjectViewModel viewModel)
        {
            _repository.Edit(viewModel.ToProjectEntity());
            _repository.Save();
        }

        public ProjectViewModel Add(ProjectViewModel viewModel)
        {
            var model = _repository.Add(viewModel.ToProjectEntity());
            _repository.Save();
            return new ProjectViewModel(model);
        }

        public void Delete(ProjectViewModel viewModel)
        {
            _repository.Delete(viewModel.ToProjectEntity());
            _repository.Save();
        }
    }
}
