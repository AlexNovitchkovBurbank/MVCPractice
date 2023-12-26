using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCPractice.Controllers;
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
        public void GetByUserId()
        {
            string idAsString = Guid.NewGuid().ToString();

            IList<Item> records = new List<Item>();
            string stringOfRecords = "";

            Mock<IByIdRecordGetterProcessor> recordPosterProcessorMock = new Mock<IByIdRecordGetterProcessor>();
            Mock<IStringAllRecordsIntoOneCreator> stringAllRecordsIntoOneCreatorMock = new Mock<IStringAllRecordsIntoOneCreator>();

            recordPosterProcessorMock.Setup(c => c.Process(idAsString)).Returns(records);
            stringAllRecordsIntoOneCreatorMock.Setup(c => c.Create(records)).Returns(stringOfRecords);

            ByIdRecordGetterController byIdRecordGetterController = new ByIdRecordGetterController(recordPosterProcessorMock.Object, stringAllRecordsIntoOneCreatorMock.Object);

            var result = byIdRecordGetterController.GetByUserId(idAsString);

            Assert.IsInstanceOf(typeof(ViewResult), result);

            recordPosterProcessorMock.Verify(c => c.Process(idAsString), Times.Once);
            stringAllRecordsIntoOneCreatorMock.Verify(c => c.Create(records), Times.Once);

            recordPosterProcessorMock.VerifyNoOtherCalls();
            stringAllRecordsIntoOneCreatorMock.VerifyNoOtherCalls();
        }
    }
}
