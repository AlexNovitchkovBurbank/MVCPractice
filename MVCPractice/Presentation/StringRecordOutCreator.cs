using MVCPractice.Models.dbContext;

namespace MVCPractice.Presentation
{
    public class StringRecordOutCreator : IStringRecordOutCreator
    {
        public string Create(Item record)
        {
            var stringOfRecords = record.Id.ToString().PadRight(45, '\u00A0') + record.Name + '\n';

            return stringOfRecords;
        }
    }
}
