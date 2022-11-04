using Microsoft.EntityFrameworkCore;

namespace TestCalendar;

public class ApplicationContext : DbContext
{
    public DbSet<Event> Events { get; set; } = null!;
 
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=karysel55");
    }
}