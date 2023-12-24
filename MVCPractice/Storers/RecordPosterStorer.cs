using MVCPractice.Models.dbContext;

namespace MVCPractice.Storers
{
    public class RecordPosterStorer : IRecordPosterStorer
    {
        private readonly ItemsContext itemsContext;

        public RecordPosterStorer(ItemsContext itemsContext)
        {
            this.itemsContext = itemsContext;
        }

        public void Store(Item item)
        {
            itemsContext.Database.EnsureCreated();

            itemsContext.Records.Add(item);

            itemsContext.SaveChanges();
        }
    }
}