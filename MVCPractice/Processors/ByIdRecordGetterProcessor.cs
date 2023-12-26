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

        public IList<Item> Process(string idAsString)
        {
            var valid = byIdRecordGetterValidator.Validate(idAsString);

            if (!valid)
                throw new Exception("id provided is not valid");

            var idAsGuid = byIdRecordGetterMapper.Map(idAsString);
            var allRecords = byIdRecordGetterGetFromDatabase.Get();
            var filteredRecords = onIdFilterer.Filter(allRecords, idAsGuid);

            return filteredRecords;
        }
    }
}