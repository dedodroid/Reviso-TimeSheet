using Reviso.TimeSheet.Entities;
using System;

namespace Reviso.TimeSheet.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProjectViewModel()
        {
        }

        public ProjectViewModel(ProjectEntity project)
        {
            if (project == null)
            {
                return;
            }

            ProjectId = project.Id;
            Name = project.Name;
            Description = project.Description;
        }

        public ProjectEntity ToProjectEntity()
        {
            return new ProjectEntity
            {
                Id = ProjectId,
                Name = Name,
                Description = Description
            };
        }
    }
}