using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCPractice.Controllers;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using MVCPractice.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Controllers
{
    public class ByIdRecordGetterControllerTests
    {
        [Test]
        public void GetByUserId_NoExceptions()
        {
            string idAsString = Guid.NewGuid().ToString();

            Item record = new Item();
            //string recordStringedOut = "";

            Mock<IByIdRecordGetterProcessor> recordPosterProcessorMock = new Mock<IByIdRecordGetterProcessor>();
            Mock<IStringRecordOutCreator> stringAllRecordsIntoOneCreatorMock = new Mock<IStringRecordOutCreator>();

            Microsoft.AspNetCore.Mvc.JsonResult recordAsJsonResult = new Microsoft.AspNetCore.Mvc.JsonResult(record);

            recordPosterProcessorMock.Setup(c => c.Process(idAsString)).Returns(record);
            //stringAllRecordsIntoOneCreatorMock.Setup(c => c.Create(record)).Returns(recordStringedOut);

            ByIdRecordGetterController byIdRecordGetterController = new ByIdRecordGetterController(recordPosterProcessorMock.Object, stringAllRecordsIntoOneCreatorMock.Object);

            var result = byIdRecordGetterController.GetByUserId(idAsString);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);

            var resultAsOkResult = result as OkObjectResult;

            Assert.NotNull(resultAsOkResult.Value);

            Assert.IsInstanceOf<JsonResult>(resultAsOkResult.Value);

            var actualJsonResult = resultAsOkResult.Value as JsonResult;

            Assert.That(recordAsJsonResult.Value, Is.EqualTo(actualJsonResult.Value));

            recordPosterProcessorMock.Verify(c => c.Process(idAsString), Times.Once);
            //stringAllRecordsIntoOneCreatorMock.Verify(c => c.Create(record), Times.Once);

            recordPosterProcessorMock.VerifyNoOtherCalls();
            //stringAllRecordsIntoOneCreatorMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetByUserId_Exception()
        {
            string idAsString = Guid.NewGuid().ToString();

            //string recordStringedOut = "";

            Mock<IByIdRecordGetterProcessor> recordPosterProcessorMock = new Mock<IByIdRecordGetterProcessor>();
            Mock<IStringRecordOutCreator> stringAllRecordsIntoOneCreatorMock = new Mock<IStringRecordOutCreator>();

            Microsoft.AspNetCore.Mvc.JsonResult recordAsJsonResult = new Microsoft.AspNetCore.Mvc.JsonResult("id is not a guid");

            recordPosterProcessorMock.Setup(c => c.Process(idAsString)).Throws(new Exception("id is not a guid"));
            //stringAllRecordsIntoOneCreatorMock.Setup(c => c.Create(record)).Returns(recordStringedOut);

            ByIdRecordGetterController byIdRecordGetterController = new ByIdRecordGetterController(recordPosterProcessorMock.Object, stringAllRecordsIntoOneCreatorMock.Object);

            var result = byIdRecordGetterController.GetByUserId(idAsString);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);

            var resultAsOkResult = result as OkObjectResult;

            Assert.NotNull(resultAsOkResult.Value);

            Assert.IsInstanceOf<JsonResult>(resultAsOkResult.Value);

            var actualJsonResult = resultAsOkResult.Value as JsonResult;

            Assert.That(recordAsJsonResult.Value, Is.EqualTo(actualJsonResult.Value));

            recordPosterProcessorMock.Verify(c => c.Process(idAsString), Times.Once);
            //stringAllRecordsIntoOneCreatorMock.Verify(c => c.Create(record), Times.Once);

            recordPosterProcessorMock.VerifyNoOtherCalls();
            //stringAllRecordsIntoOneCreatorMock.VerifyNoOtherCalls();
        }
    }
}
