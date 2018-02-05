using Reviso.TimeSheet.DC.Services.Interfaces;
using Reviso.TimeSheet.Repositories;
using Reviso.TimeSheet.Repositories.Repository;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Reviso.TimeSheet.ViewModels;
using System;
using System.Web.Http;

namespace Reviso.TimeSheet.WebApi.Controllers
{
    [RoutePrefix("api/TimeSheet")]
    public class TimeSheetController : ApiController, IController
    {
        private ITimeSheetService _timeSheetService;

        public TimeSheetController(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        [Route("GetRecords"), HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = _timeSheetService.GetAll();
            return Ok(model);
        }

        [Route("UpdateRecord"), HttpPost]
        public IHttpActionResult Edit(TimeSheetViewModel viewModel)
        {
            try
            {
                _timeSheetService.Edit(viewModel);
                return Ok(new { message = "Record has been successfully updated." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddRecord")]
        public IHttpActionResult Add(TimeSheetViewModel viewModel)
        {
            try
            {
                var model =_timeSheetService.Add(viewModel);
                model = _timeSheetService.GetSingle(model.TimeSheetId);
                return Ok(new { message = "Record has been successfully added.", recordAdded = model });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Route("DeleteRecord"), HttpPost]
        public IHttpActionResult Delete(TimeSheetViewModel viewModel)
        {
            try
            {
                _timeSheetService.Delete(viewModel);
                return Ok(new { message = "Record has been successfully deleted." });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

    }
}