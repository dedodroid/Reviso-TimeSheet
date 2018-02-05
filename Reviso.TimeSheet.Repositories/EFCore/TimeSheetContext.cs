using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Reviso.TimeSheet.Entities;

namespace Reviso.TimeSheet.Repositories
{
    public class TimeSheetContext : IdentityDbContext 
    {
        public TimeSheetContext() : base("TimeSheetContext")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<TimeSheetContext>());
            Database.SetInitializer<TimeSheetContext>(new DropCreateDatabaseIfModelChanges<TimeSheetContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<TimeSheetContext>());
            Database.SetInitializer(new Initializer());
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TimeSheetEntity> TimeSheets { get; set; }
    }
}