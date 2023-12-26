using MVCPractice.Models.dbContext;

namespace MVCPractice.Utilities
{
    public class OnIdFilterer : IOnIdFilterer
    {
        public IList<Item> Filter(IList<Item> records, Guid id)
        {
            if (records == null)
                throw new ArgumentException("list of records cannot be null");

            var newList = new List<Item>();

            foreach (var record in records)
                if (id == record.Id)
                    newList.Add(record);

            return newList;
        }
    }
}
