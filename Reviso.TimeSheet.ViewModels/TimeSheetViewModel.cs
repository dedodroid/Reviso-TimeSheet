using Reviso.TimeSheet.Entities;
using System;

namespace Reviso.TimeSheet.ViewModels
{
    public class TimeSheetViewModel
    {
        public int TimeSheetId { get; set; }
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public short RegularHours { get; set; }
        public short OverTimeHours { get; set; }
        // Foreign key for Customer 
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }

        // Foreign key for Project
        public int ProjectId { get; set; }
        public ProjectViewModel Project { get; set; }

        public TimeSheetViewModel()
        {
        }

        public TimeSheetViewModel(TimeSheetEntity timeSheet)
        {
            if (timeSheet == null)
            {
                return;
            }

            TimeSheetId = timeSheet.Id;
            Date = timeSheet.Date;
            TaskDescription = timeSheet.TaskDescription;
            RegularHours = timeSheet.RegularHours;

            OverTimeHours = timeSheet.OverTimeHours;
            CustomerId = timeSheet.CustomerId;
            ProjectId = timeSheet.ProjectId;
            Customer = new CustomerViewModel(timeSheet.Customer);
            Project = new ProjectViewModel(timeSheet.Project);
        }

        public TimeSheetEntity ToTimeSheetEntity()
        {
            return new TimeSheetEntity
            {
                Id = TimeSheetId,
                Date = Date,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                CustomerId = CustomerId,
                ProjectId = ProjectId,
                Customer = Customer != null ? Customer.ToCustomerEntity() : null,
                Project = Project != null ? Project.ToProjectEntity() : null,
                TaskDescription = TaskDescription
            };
        }
    }
}