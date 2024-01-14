using Microsoft.AspNetCore.Mvc;
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
        private readonly IStringToGuidConverter converters;
        private readonly IRecordPosterMapper recordPosterMapper;
        private IRecordPosterStorer recordPosterStorer;

        public RecordPosterProcessor(IRecordPosterValidator recordPosterValidator, IStringToGuidConverter converters, IRecordPosterMapper recordPosterMapper, IRecordPosterStorer recordPosterStorer)
        {
            this.recordPosterValidator = recordPosterValidator;
            this.converters = converters;
            this.recordPosterMapper = recordPosterMapper;
            this.recordPosterStorer = recordPosterStorer;
        }

        public void Process(string idAsString, string name)
        {
            var errorObjectForId = recordPosterValidator.ValidateId(idAsString);

            if (!errorObjectForId.Valid)
                throw new Exception(errorObjectForId.Message);

            var errorObjectForName = recordPosterValidator.ValidateName(name);

            if (!errorObjectForName.Valid)
                throw new Exception(errorObjectForName.Message);

            var id = converters.Convert(idAsString);
            var item = recordPosterMapper.Map(id, name);

            recordPosterStorer.Store(item);
        }
    }
}