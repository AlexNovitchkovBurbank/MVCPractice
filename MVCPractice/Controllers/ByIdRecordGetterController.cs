using Microsoft.AspNetCore.Mvc;
using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using MVCPractice.Processors;

namespace MVCPractice.Controllers
{
    public class ByIdRecordGetterController : Controller
    {
        private readonly IByIdRecordGetterProcessor byIdRecordGetterProcessor;
        private readonly IStringRecordOutCreator stringRecordOutCreator;

        public ByIdRecordGetterController(IByIdRecordGetterProcessor byIdRecordGetterProcessor, IStringRecordOutCreator stringAllRecordsIntoOneCreator)
        {
           this.byIdRecordGetterProcessor = byIdRecordGetterProcessor;
           this.stringRecordOutCreator = stringAllRecordsIntoOneCreator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetByUserId(string userIdGuid)
        {
            var records = byIdRecordGetterProcessor.Process(userIdGuid);

            return new OkObjectResult(Json(records));

            //var recordsAsAString = stringAllRecordsIntoOneCreator.Create(records);

            //ViewData["recordsAsAString"] = recordsAsAString;

            //return View();
        }
    }
}
