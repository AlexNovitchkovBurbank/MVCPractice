using Moq;
using MVCPractice;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Processors;
using MVCPractice.Storers;
using MVCPractice.Utilities;
using MVCPractice.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Processors
{
    public class RecordPosterProcessorTests
    {
        [Test]
        public void ProcessAllValid()
        {
            string name = "Alex";

            Guid id = Guid.NewGuid();

            var idAsString = id.ToString();

            Item item = new Item();
            item.Id = id;
            item.Name = name;

            Error errorObjectForId = new Error();
            errorObjectForId.Valid = true;
            errorObjectForId.Message = "";

            Error errorObjectForName = new Error();
            errorObjectForName.Valid = true;
            errorObjectForName.Message = "";

            Mock<IRecordPosterValidator> validatorMock = new Mock<IRecordPosterValidator>();
            Mock<IStringToGuidConverter> convertersMock = new Mock<IStringToGuidConverter>();
            Mock<IRecordPosterMapper> mapperMock = new Mock<IRecordPosterMapper>();
            Mock<IRecordPosterStorer> storerMock = new Mock<IRecordPosterStorer>();

            validatorMock.Setup(c => c.ValidateName(name)).Returns(errorObjectForName);
            validatorMock.Setup(c => c.ValidateId(idAsString)).Returns(errorObjectForId);
            convertersMock.Setup(c => c.Convert(idAsString)).Returns(id);
            mapperMock.Setup(c => c.Map(id, name)).Returns(item);
            storerMock.Setup(c => c.Store(item));

            IRecordPosterProcessor recordPosterProcessor = new RecordPosterProcessor(validatorMock.Object, convertersMock.Object, mapperMock.Object, storerMock.Object);

            recordPosterProcessor.Process(idAsString, name);

            validatorMock.Verify(c => c.ValidateId(idAsString), Times.Once);
            validatorMock.Verify(c => c.ValidateName(name), Times.Once);
            convertersMock.Verify(c => c.Convert(idAsString), Times.Once);
            mapperMock.Verify(c => c.Map(id, name), Times.Once);
            storerMock.Verify(c => c.Store(item), Times.Once);

            validatorMock.VerifyNoOtherCalls();
            convertersMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            storerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void ProcessInvalidId()
        {
            string name = "Alex";
            var idAsString = "1";

            Error errorObjectForId = new Error();
            errorObjectForId.Valid = false;
            errorObjectForId.Message = "id must be a guid";

            Mock<IRecordPosterValidator> validatorMock = new Mock<IRecordPosterValidator>();
            Mock<IStringToGuidConverter> convertersMock = new Mock<IStringToGuidConverter>();
            Mock<IRecordPosterMapper> mapperMock = new Mock<IRecordPosterMapper>();
            Mock<IRecordPosterStorer> storerMock = new Mock<IRecordPosterStorer>();

            validatorMock.Setup(c => c.ValidateId(idAsString)).Returns(errorObjectForId);

            IRecordPosterProcessor recordPosterProcessor = new RecordPosterProcessor(validatorMock.Object, convertersMock.Object, mapperMock.Object, storerMock.Object);

            var ex = Assert.Throws<Exception>(() => recordPosterProcessor.Process(idAsString, name));

            Assert.That(ex.Message, Is.EqualTo(errorObjectForId.Message));

            validatorMock.Verify(c => c.ValidateId(idAsString), Times.Once);

            validatorMock.VerifyNoOtherCalls();
        }

        [Test]
        public void ProcessInvalidName()
        {
            string name = "";

            var id = Guid.NewGuid();
            var idAsString = id.ToString();

            Error errorObjectForId = new Error();
            errorObjectForId.Valid = true;
            errorObjectForId.Message = "";

            Error errorObjectForName = new Error();
            errorObjectForName.Valid = false;
            errorObjectForName.Message = "name cannot be null or only have whitespace";

            Mock<IRecordPosterValidator> validatorMock = new Mock<IRecordPosterValidator>();
            Mock<IStringToGuidConverter> convertersMock = new Mock<IStringToGuidConverter>();
            Mock<IRecordPosterMapper> mapperMock = new Mock<IRecordPosterMapper>();
            Mock<IRecordPosterStorer> storerMock = new Mock<IRecordPosterStorer>();

            validatorMock.Setup(c => c.ValidateId(idAsString)).Returns(errorObjectForId);
            validatorMock.Setup(c => c.ValidateName(name)).Returns(errorObjectForName);

            IRecordPosterProcessor recordPosterProcessor = new RecordPosterProcessor(validatorMock.Object, convertersMock.Object, mapperMock.Object, storerMock.Object);

            var ex = Assert.Throws<Exception>(() => recordPosterProcessor.Process(idAsString, name));

            Assert.That(ex.Message, Is.EqualTo(errorObjectForName.Message));

            validatorMock.Verify(c => c.ValidateId(idAsString), Times.Once);
            validatorMock.Verify(c => c.ValidateName(name), Times.Once);

            validatorMock.VerifyNoOtherCalls();
        }
    }
}
