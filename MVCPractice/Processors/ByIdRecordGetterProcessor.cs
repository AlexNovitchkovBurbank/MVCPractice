using MVCPractice.Validators;
using MVCPractice.Models.dbContext;
using MVCPractice.Mappers;
using MVCPractice.Utilities;

namespace MVCPractice.Processors
{
    public class ByIdRecordGetterProcessor : IByIdRecordGetterProcessor
    {
        private IByIdRecordGetterValidator byIdRecordGetterValidator;
        private readonly IByIdRecordGetterMapper byIdRecordGetterMapper;
        private IByIdRecordGetterGetFromDatabase byIdRecordGetterDatabase;

        public ByIdRecordGetterProcessor(IByIdRecordGetterValidator byIdRecordGetterValidator, IByIdRecordGetterMapper byIdRecordGetterMapper, IByIdRecordGetterGetFromDatabase byIdRecordGetterDatabase)
        {
            this.byIdRecordGetterValidator = byIdRecordGetterValidator;
            this.byIdRecordGetterMapper = byIdRecordGetterMapper;
            this.byIdRecordGetterDatabase = byIdRecordGetterDatabase;
        }

        public IDictionary<Guid, Item> Process(string idAsString)
        {
            var valid = byIdRecordGetterValidator.Validate(idAsString);

            if (!valid)
                throw new Exception("id provided is not valid");

            var idAsGuid = byIdRecordGetterMapper.Map(idAsString);
            var records = byIdRecordGetterDatabase.Get(idAsGuid);

            return records;
        }
    }
}