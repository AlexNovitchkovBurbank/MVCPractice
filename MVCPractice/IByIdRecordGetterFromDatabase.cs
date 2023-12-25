using MVCPractice.Models.dbContext;

namespace MVCPractice
{
    public interface IByIdRecordGetterGetFromDatabase
    {
        public IDictionary<Guid, Item> Get(Guid id);
    }
}