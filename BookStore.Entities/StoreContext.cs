using System.Data.Entity;

namespace BookStore.Entities
{
    public class StoreContext: DbContext
    {
        public StoreContext(): base("BookStoreConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
