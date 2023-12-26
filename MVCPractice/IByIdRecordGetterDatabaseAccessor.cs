using Microsoft.EntityFrameworkCore;
using MVCPractice.Models.dbContext;

namespace MVCPractice
{
    public interface IByIdRecordGetterGetDatabaseAccessor
    {
        public IList<Item> Get();
    }
}