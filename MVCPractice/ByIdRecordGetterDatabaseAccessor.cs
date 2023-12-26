using Microsoft.EntityFrameworkCore;
using MVCPractice.Models.dbContext;

namespace MVCPractice
{
    public class ByIdRecordGetterDatabaseAccessor : IByIdRecordGetterGetDatabaseAccessor
    {
        private readonly ItemsContext itemsContext;

        public ByIdRecordGetterDatabaseAccessor(ItemsContext itemsContext)
        {
            this.itemsContext = itemsContext;
        }

        public IList<Item> Get()
        {
            itemsContext.Database.EnsureCreated();

            var records = itemsContext.Records.ToList();

            return records;
        }
    }
}
