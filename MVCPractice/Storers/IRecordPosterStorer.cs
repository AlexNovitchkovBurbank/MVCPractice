using MVCPractice.Models.dbContext;

namespace MVCPractice.Storers
{
    public interface IRecordPosterStorer
    {
        public void Store(Item item);
    }
}