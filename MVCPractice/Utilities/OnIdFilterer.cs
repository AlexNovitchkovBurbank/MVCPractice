using MVCPractice.Models.dbContext;

namespace MVCPractice.Utilities
{
    public class OnIdFilterer : IOnIdFilterer
    {
        public Item Filter(IList<Item> records, Guid id)
        {
            if (records == null)
                throw new ArgumentException("list of records cannot be null");

            var item = new Item();

            foreach (var record in records)
                if (id == record.Id)
                    item = record;

            return item;
        }
    }
}
