using MVCPractice.Models.dbContext;

namespace MVCPractice.Presentation
{
    public interface IStringRecordOutCreator
    {
        public string Create(Item record);
    }
}