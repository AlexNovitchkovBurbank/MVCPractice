using Moq;
using MVCPractice;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Processors;
using MVCPractice.Utilities;
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
            Guid id = Guid.NewGuid();

            string idAsString = id.ToString();
            Guid idAsGuid = id;

            Item item = new Item();
            item.Id = id;
            item.Name = "Test";

            IList<Item> records = new List<Item>
            {
                item
            };

            Mock<IByIdRecordGetterValidator> validatorMock = new Mock<IByIdRecordGetterValidator>();
            Mock<IByIdRecordGetterMapper> mapperMock = new Mock<IByIdRecordGetterMapper>();
            Mock<IByIdRecordGetterGetDatabaseAccessor> databaseMock = new Mock<IByIdRecordGetterGetDatabaseAccessor>();
            Mock<IOnIdFilterer> onIdFilterer = new Mock<IOnIdFilterer>();

            validatorMock.Setup(c => c.Validate(idAsString)).Returns(true);
            mapperMock.Setup(c => c.Map(idAsString)).Returns(idAsGuid);
            databaseMock.Setup(c => c.Get()).Returns(records);
            onIdFilterer.Setup(c => c.Filter(records, id)).Returns(item);

            ByIdRecordGetterProcessor recordPosterProcessor = new ByIdRecordGetterProcessor(validatorMock.Object, mapperMock.Object, databaseMock.Object, onIdFilterer.Object);

            var result = recordPosterProcessor.Process(idAsString);

            Assert.That(result.Id, Is.EqualTo(item.Id));
            Assert.That(result.Name, Is.EqualTo(item.Name));

            validatorMock.Verify(c => c.Validate(idAsString), Times.Once);
            mapperMock.Verify(c => c.Map(idAsString), Times.Once);
            databaseMock.Verify(c => c.Get(), Times.Once);
            onIdFilterer.Verify(c => c.Filter(records, idAsGuid), Times.Once);

            validatorMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            databaseMock.VerifyNoOtherCalls();
            onIdFilterer.VerifyNoOtherCalls();
        }
    }
}
