using MVCPractice.Models.dbContext;

namespace MVCPractice.Processors
{
    public interface IRecordPosterProcessor
    {
        public void Process(string idAsString, string name);
    }
}