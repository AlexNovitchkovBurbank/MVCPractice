using MVCPractice.Models.dbContext;

namespace MVCPractice
{
    public class ByIdRecordGetterFromDatabase : IByIdRecordGetterGetFromDatabase
    {
        public IDictionary<Guid, Item> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
