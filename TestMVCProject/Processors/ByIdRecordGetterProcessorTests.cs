using Moq;
using MVCPractice;
using MVCPractice.Mappers;
using MVCPractice.Processors;
using MVCPractice.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Processors
{
    public class ByIdRecordGetterProcessorTests
    {
        [Test]
        public void ProcessAllValid()
        {
            Guid guid = Guid.NewGuid();

            string idAsString = guid.ToString();
            Guid idAsGuid = guid;

            Mock<IByIdRecordGetterValidator> validatorMock = new Mock<IByIdRecordGetterValidator>();
            Mock<IByIdRecordGetterMapper> mapperMock = new Mock<IByIdRecordGetterMapper>();
            Mock<IByIdRecordGetterGetFromDatabase> databaseMock = new Mock<IByIdRecordGetterGetFromDatabase>();

            validatorMock.Setup(c => c.Validate(idAsString)).Returns(true);
            mapperMock.Setup(c => c.Map(idAsString)).Returns(idAsGuid);

            ByIdRecordGetterProcessor recordPosterProcessor = new ByIdRecordGetterProcessor(validatorMock.Object, mapperMock.Object, databaseMock.Object);

            recordPosterProcessor.Process(idAsString);

            validatorMock.Verify(c => c.Validate(idAsString), Times.Once);
            mapperMock.Verify(c => c.Map(idAsString), Times.Once);
            databaseMock.Verify(c => c.Get(idAsGuid), Times.Once);

            validatorMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            databaseMock.VerifyNoOtherCalls();
        }
    }
}
