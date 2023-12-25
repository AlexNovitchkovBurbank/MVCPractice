using MVCPractice.Models.dbContext;
using MVCPractice.Utilities;

namespace MVCPractice
{
    public class ByIdRecordGetterFromDatabase : IByIdRecordGetterGetFromDatabase
    {
        private readonly ItemsContext itemsContext;

        public ByIdRecordGetterFromDatabase(ItemsContext itemsContext)
        {
            this.itemsContext = itemsContext;
        }

        public IList<Item> Get(Guid id)
        {
            itemsContext.Database.EnsureCreated();

            var records = itemsContext.Records.ToList();

            return records;
        }
    }
}
