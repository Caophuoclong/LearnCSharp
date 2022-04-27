using Microsoft.EntityFrameworkCore;

namespace BookCollection.Model;

public class BookCollectionContext: DbContext
{
    public DbSet<Account> _accounts { get; set; }
    public DbSet<User> _users { get; set; }

    public BookCollectionContext(
        DbContextOptions<BookCollectionContext> options) : base(options)
    {
    }

    

}