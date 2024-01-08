using MVCPractice.Models.dbContext;

namespace MVCPractice.Utilities
{
    public interface IOnIdFilterer
    {
        public Item Filter(IList<Item> records, Guid id);
    }
}