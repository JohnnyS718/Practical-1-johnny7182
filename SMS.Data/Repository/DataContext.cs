using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SMS.Data.Models;

namespace SMS.Data.Repository;

public class DataContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Filename=data.db")
            //.LogTo(Console.WriteLine, LogLevel.Information)
            ;
    }

    public void Initialise() 
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
}
 
