using MVCPractice.Models.dbContext;

namespace MVCPractice.Mappers
{
    public class RecordPosterMapper : IRecordPosterMapper
    {
        public Item Map(Guid id, string name)
        {
            if (name == null)
                throw new ArgumentException("name cannot be null");

            Item item = new Item();

            item.Id = id;
            item.Name = name;

            return item;
        }
    }
}
