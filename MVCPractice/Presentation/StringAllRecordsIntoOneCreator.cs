using MVCPractice.Models.dbContext;

namespace MVCPractice.Presentation
{
    public class StringAllRecordsIntoOneCreator : IStringAllRecordsIntoOneCreator
    {
        public string Create(IList<Item> records)
        {
            var stringOfRecords = "";
            foreach (var record in records)
                stringOfRecords += record.Id.ToString().PadRight(45, '\u00A0') + record.Name + '\n';

            return stringOfRecords;
        }
    }
}
