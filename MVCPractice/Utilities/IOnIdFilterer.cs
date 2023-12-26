using MVCPractice.Models.dbContext;

namespace MVCPractice.Utilities
{
    public interface IOnIdFilterer
    {
        public IList<Item> Filter(IList<Item> records, Guid id);
    }
}