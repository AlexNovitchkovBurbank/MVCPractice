namespace MVCPractice.Models
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    namespace dbContext
    {
        public class ItemsContext : DbContext
        {
            public DbSet<Item> Records { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9CPS9TC\SQLEXPRESS;Initial Catalog=itemsDatabase;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
            }
        }

        public class Item
        {
            public Item()
            {
                Id = Guid.Empty;
                Name = string.Empty;
            }

            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }
}
