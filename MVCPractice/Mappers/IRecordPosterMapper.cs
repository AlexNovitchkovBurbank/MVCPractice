using MVCPractice.Models.dbContext;

namespace MVCPractice.Mappers
{
    public interface IRecordPosterMapper
    {
        public Item Map(Guid id, string name);
    }
}