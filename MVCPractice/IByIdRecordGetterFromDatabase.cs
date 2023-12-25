using MVCPractice.Models.dbContext;

namespace MVCPractice
{
    public interface IByIdRecordGetterGetFromDatabase
    {
        public IList<Item> Get(Guid id);
    }
}