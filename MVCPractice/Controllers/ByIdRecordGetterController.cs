using Microsoft.AspNetCore.Mvc;
using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using MVCPractice.Processors;
using System.Security.Cryptography.Pkcs;

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
            Item record = new Item();

            try
            {
                record = byIdRecordGetterProcessor.Process(userIdGuid);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(Json(ex.Message));
            }

            return new OkObjectResult(Json(record));
            //var recordsAsAString = stringAllRecordsIntoOneCreator.Create(records);

            //ViewData["recordsAsAString"] = recordsAsAString;

            //return View();
        }
    }
}
