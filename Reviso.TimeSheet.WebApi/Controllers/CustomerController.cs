using Reviso.TimeSheet.DC.Services;
using Reviso.TimeSheet.DC.Services.Interfaces;
using Reviso.TimeSheet.Repositories;
using Reviso.TimeSheet.Repositories.Repository;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.ViewModels;
using System;
using System.Web.Http;

namespace Reviso.TimeSheet.WebApi.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController, IController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("GetRecords"), HttpGet]
        [AllowAnonymous]

        public IHttpActionResult GetAll()
        {
            var model = _customerService.GetAll();
            return Ok(model);
        }

        [Route("UpdateRecord"), HttpPost]
        public IHttpActionResult Edit(CustomerViewModel viewModel)
        {
            try
            {
                _customerService.Edit(viewModel);
                return Ok(new { message = "Record has been successfully updated." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Route("AddRecord"), HttpPost]
        public IHttpActionResult Add(CustomerViewModel viewModel)
        {
            try
            {
                var model =_customerService.Add(viewModel);
                return Ok(new { message = "Record has been successfully added.", customerAdded = model });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Route("DeleteRecord"), HttpPost]
        public IHttpActionResult Delete(CustomerViewModel viewModel)
        {
            try
            {
                _customerService.Delete(viewModel);
                return Ok(new { message = "Record has been successfully deleted." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

    }
}