using Reviso.TimeSheet.DC.Services.Interfaces;
using Reviso.TimeSheet.Repositories;
using Reviso.TimeSheet.Repositories.Repository;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.ViewModels;
using System;
using System.Web.Http;

namespace Reviso.TimeSheet.WebApi.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController, IController
    {
        private readonly IProjectService _projectService;
        private readonly ICustomerService _customerService;

        public ProjectController(IProjectService projectService, ICustomerService customerService)
        {
            _projectService = projectService;
            _customerService = customerService;
        }

        [Route("GetRecords"), HttpGet]

        public IHttpActionResult GetAll()
        {
            var model = _projectService.GetAll();
            return Ok(model);
        }

        [Route("UpdateRecord"), HttpPost]
        public IHttpActionResult Edit(ProjectViewModel viewModel)
        {
            try
            {
                _projectService.Edit(viewModel);
                return Ok(new { message = "Record has been successfully updated." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Route("AddRecord"), HttpPost]
        public IHttpActionResult Add(ProjectViewModel viewModel)
        {
            try
            {
                var model = _projectService.Add(viewModel);
                return Ok(new { message = "Record has been successfully added.", recordAdded = model });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Route("DeleteRecord"), HttpPost]
        public IHttpActionResult Delete(ProjectViewModel viewModel)
        {
            try
            {
                _projectService.Delete(viewModel);
                return Ok(new { message = "Record has been successfully deleted." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

    }
}