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
        public void PostUserRecord()
        {
            string name = "Alex";

            Mock<ILogger<HomeController>> loggerMock = new Mock<ILogger<HomeController>>();
            Mock<IRecordPosterProcessor> recordPosterProcessorMock = new Mock<IRecordPosterProcessor>();

            HomeController homeController = new HomeController(loggerMock.Object, recordPosterProcessorMock.Object);

            var result = homeController.PostUserRecord(name);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }
    }
}
