using MVCPractice.Models.dbContext;

namespace MVCPractice.Presentation
{
    public interface IStringAllRecordsIntoOneCreator
    {
        public string Create(IList<Item> records);
    }
}