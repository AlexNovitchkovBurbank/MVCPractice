using MVCPractice.Models.dbContext;

namespace MVCPractice.Processors
{
    public interface IByIdRecordGetterProcessor
    {
        IList<Item> Process(string id);
    }
}