﻿using Moq;
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

            Item item = new Item();
            item.Id = id;
            item.Name = "Alex";

            Error error = new Error();
            error.Valid = true;
            error.Message = "";

            Mock<IRecordPosterValidator> validatorMock = new Mock<IRecordPosterValidator>();
            Mock<IGuidCreator> guidCreatorMock = new Mock<IGuidCreator>();
            Mock<IRecordPosterMapper> mapperMock = new Mock<IRecordPosterMapper>();
            Mock<IRecordPosterStorer> storerMock = new Mock<IRecordPosterStorer>();

            validatorMock.Setup(c => c.Validate(name)).Returns(error);
            guidCreatorMock.Setup(c => c.Create()).Returns(id);
            mapperMock.Setup(c => c.Map(id, name)).Returns(item);
            storerMock.Setup(c => c.Store(item));

            IRecordPosterProcessor recordPosterProcessor = new RecordPosterProcessor(validatorMock.Object, guidCreatorMock.Object, mapperMock.Object, storerMock.Object);

            recordPosterProcessor.Process(name);

            validatorMock.Verify(c => c.Validate(name), Times.Once);
            mapperMock.Verify(c => c.Map(id, name), Times.Once);
            storerMock.Verify(c => c.Store(item), Times.Once);

            validatorMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            storerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void ProcessInvalidName()
        {
            string pathWithName = "/Alex";
            string name = "/Alex";

            Item item = new Item();
            item.Id = Guid.NewGuid();
            item.Name = "Alex";

            Error error = new Error();
            error.Valid = false;
            error.Message = "name cannot be null or only have whitespace";

            Mock<IRecordPosterValidator> validatorMock = new Mock<IRecordPosterValidator>();
            Mock<IGuidCreator> guidCreatorMock = new Mock<IGuidCreator>();
            Mock<IRecordPosterMapper> mapperMock = new Mock<IRecordPosterMapper>();
            Mock<IRecordPosterStorer> storerMock = new Mock<IRecordPosterStorer>();

            validatorMock.Setup(c => c.Validate(name)).Returns(error);

            IRecordPosterProcessor recordPosterProcessor = new RecordPosterProcessor(validatorMock.Object, guidCreatorMock.Object, mapperMock.Object, storerMock.Object);

            var ex = Assert.Throws<Exception>(() => recordPosterProcessor.Process(pathWithName));

            Assert.That(ex.Message, Is.EqualTo(error.Message));

            validatorMock.Verify(c => c.Validate(name), Times.Once);

            validatorMock.VerifyNoOtherCalls();
        }
    }
}
