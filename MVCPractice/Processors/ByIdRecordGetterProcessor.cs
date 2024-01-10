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
        private IByIdRecordGetterGetDatabaseAccessor byIdRecordGetterGetFromDatabase;
        private readonly IOnIdFilterer onIdFilterer;

        public ByIdRecordGetterProcessor(IByIdRecordGetterValidator byIdRecordGetterValidator, IByIdRecordGetterMapper byIdRecordGetterMapper, IByIdRecordGetterGetDatabaseAccessor byIdRecordGetterDatabaseAccessor, IOnIdFilterer onIdFilterer)
        {
            this.byIdRecordGetterValidator = byIdRecordGetterValidator;
            this.byIdRecordGetterMapper = byIdRecordGetterMapper;
            this.byIdRecordGetterGetFromDatabase = byIdRecordGetterDatabaseAccessor;
            this.onIdFilterer = onIdFilterer;
        }

        public Item Process(string idAsString)
        {
            var errorObject = byIdRecordGetterValidator.Validate(idAsString);

            if (!errorObject.Valid)
                throw new Exception(errorObject.Message);

            var idAsGuid = byIdRecordGetterMapper.Map(idAsString);
            var allRecords = byIdRecordGetterGetFromDatabase.Get();
            var record = onIdFilterer.Filter(allRecords, idAsGuid);

            return record;
        }
    }
}