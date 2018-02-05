using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
//using System.IdentityModel.Claims;
using System.Security.Claims;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Reviso.TimeSheet.Entities;

namespace Reviso.TimeSheet.Repositories
{
    public class Configuration : DbMigrationsConfiguration<TimeSheetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TimeSheetContext context)
        {
            if (context.Customers.Any()) return;

            // Creating some projects
            var projectOne = new ProjectEntity() { Id = 1, Name = "Boring Project", Description = "A very boring project" };
            var projectTwo = new ProjectEntity() { Id = 2, Name = "Amazing Project", Description = "A very exciting project" };

            // Creating some projects
            var projectThree = new ProjectEntity() { Id = 3, Name = "The Project of the life", Description = "This is a very beautiful project" };
            var projectFour = new ProjectEntity() { Id = 4, Name = "Normal Project", Description = "Common fun project" };

            // Creating a customer
            var customer = new CustomerEntity() { Id = 1, FirstName = "Mark", LastName = "Zuckerberg", Address = "1 Hacker Way, 94025 Menlo Park, CA", Email = "info@facebook.com" };
            context.Customers.AddOrUpdate(customer);

            // Creating a customer
            var customerTwo = new CustomerEntity() { Id = 2, FirstName = "", LastName = "Software House", Address = "Via Delle vie, 14, Milano", Email = "info@swhouse.com" };
            context.Customers.AddOrUpdate(customerTwo);

            //Create a record on timesheet
            var timeSheet = new TimeSheetEntity();
            timeSheet.Project = projectOne;
            timeSheet.Customer = customer;
            timeSheet.Date = DateTime.Now;
            timeSheet.TaskDescription = "Backend bug fixing";
            timeSheet.RegularHours = 8;
            timeSheet.OverTimeHours = 2;
            context.TimeSheets.AddOrUpdate(timeSheet);

            //Create a record on timesheet
            timeSheet = new TimeSheetEntity();
            timeSheet.Project = projectTwo;
            timeSheet.Customer = customer;
            timeSheet.Date = DateTime.Now;
            timeSheet.TaskDescription = "Frontend bug fixing";
            timeSheet.RegularHours = 8;
            timeSheet.OverTimeHours = 3;
            context.TimeSheets.AddOrUpdate(timeSheet);

            //Create a record on timesheet
            timeSheet = new TimeSheetEntity();
            timeSheet.Project = projectThree;
            timeSheet.Customer = customerTwo;
            timeSheet.Date = DateTime.Now;
            timeSheet.TaskDescription = "Bug fixing and staging deploy";
            timeSheet.RegularHours = 8;
            timeSheet.OverTimeHours = 1;
            context.TimeSheets.AddOrUpdate(timeSheet);

            //Create a record on timesheet
            timeSheet = new TimeSheetEntity();
            timeSheet.Project = projectFour;
            timeSheet.Customer = customerTwo;
            timeSheet.Date = DateTime.Now;
            timeSheet.TaskDescription = "Bug fixing and production deploy";
            timeSheet.RegularHours = 11;
            timeSheet.OverTimeHours = 1;
            context.TimeSheets.AddOrUpdate(timeSheet);

            context.SaveChanges();
        }
    }
}