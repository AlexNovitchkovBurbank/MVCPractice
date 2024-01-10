﻿using Microsoft.AspNetCore.Mvc;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Storers;
using MVCPractice.Utilities;
using MVCPractice.Validators;

namespace MVCPractice.Processors
{
    public class RecordPosterProcessor : IRecordPosterProcessor
    {
        private IRecordPosterValidator recordPosterValidator;
        private readonly IGuidCreator guidCreator;
        private readonly IRecordPosterMapper recordPosterMapper;
        private IRecordPosterStorer recordPosterStorer;

        public RecordPosterProcessor(IRecordPosterValidator recordPosterValidator, IGuidCreator guidCreator, IRecordPosterMapper recordPosterMapper, IRecordPosterStorer recordPosterStorer)
        {
            this.recordPosterValidator = recordPosterValidator;
            this.guidCreator = guidCreator;
            this.recordPosterMapper = recordPosterMapper;
            this.recordPosterStorer = recordPosterStorer;
        }

        public void Process(string name)
        {
            var errorObject = recordPosterValidator.Validate(name);

            if (!errorObject.Valid)
                throw new Exception(errorObject.Message);

            var id = guidCreator.Create();
            var item = recordPosterMapper.Map(id, name);

            recordPosterStorer.Store(item);
        }
    }
}