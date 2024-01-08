using MVCPractice.Models.dbContext;

namespace MVCPractice.Processors
{
    public interface IByIdRecordGetterProcessor
    {
        Item Process(string idAsString);
    }
}