using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Data;
public class  DataContext : DbContext
{
    public  DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }

}
