using MVCPractice.Models.dbContext;

namespace MVCPractice.Processors
{
    public interface IByIdRecordGetterProcessor
    {
        IDictionary<Guid, Item> Process(string id);
    }
}