using MVCPractice.Models.dbContext;

namespace MVCPractice.Utilities
{
    public interface IConvertToDictionary
    {
        IDictionary<int, Item> Convert(IList<Item> records);
    }
}