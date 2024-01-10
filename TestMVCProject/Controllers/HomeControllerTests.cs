using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MVCPractice.Controllers;
using MVCPractice.Processors;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Controllers
{
    public class HomeControllerTests
    {
        [Test]
        public void PostUserRecord_NoExceptions()
        {
            string name = "Alex";

            Mock<ILogger<HomeController>> loggerMock = new Mock<ILogger<HomeController>>();
            Mock<IRecordPosterProcessor> recordPosterProcessorMock = new Mock<IRecordPosterProcessor>();

            Microsoft.AspNetCore.Mvc.JsonResult nameInJsonResult = new Microsoft.AspNetCore.Mvc.JsonResult("Successfully saved!");

            recordPosterProcessorMock.Setup(c => c.Process(name));

            HomeController homeController = new HomeController(loggerMock.Object, recordPosterProcessorMock.Object);

            var result = homeController.PostUserRecord(name);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);

            var resultAsOkResult = result as OkObjectResult;

            Assert.NotNull(resultAsOkResult.Value);

            Assert.IsInstanceOf<JsonResult>(resultAsOkResult.Value);

            var actualJsonResult = resultAsOkResult.Value as JsonResult;

            Assert.That(actualJsonResult.Value, Is.EqualTo(nameInJsonResult.Value));

            recordPosterProcessorMock.Verify(c => c.Process(name), Times.Once);

            recordPosterProcessorMock.VerifyNoOtherCalls();
        }

        [Test]
        public void PostUserRecord_Exception()
        {
            string name = "  ";

            Mock<ILogger<HomeController>> loggerMock = new Mock<ILogger<HomeController>>();
            Mock<IRecordPosterProcessor> recordPosterProcessorMock = new Mock<IRecordPosterProcessor>();

            Microsoft.AspNetCore.Mvc.JsonResult nameInJsonResult = new Microsoft.AspNetCore.Mvc.JsonResult("name cannot be null or only have whitespace");

            recordPosterProcessorMock.Setup(c => c.Process(name)).Throws(new Exception("name cannot be null or only have whitespace"));

            HomeController homeController = new HomeController(loggerMock.Object, recordPosterProcessorMock.Object);

            var result = homeController.PostUserRecord(name);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);

            var resultAsOkResult = result as OkObjectResult;

            Assert.NotNull(resultAsOkResult.Value);

            Assert.IsInstanceOf<JsonResult>(resultAsOkResult.Value);

            var actualJsonResult = resultAsOkResult.Value as JsonResult;

            Assert.That(actualJsonResult.Value, Is.EqualTo(nameInJsonResult.Value));

            recordPosterProcessorMock.Verify(c => c.Process(name), Times.Once);

            recordPosterProcessorMock.VerifyNoOtherCalls();
        }
    }
}
