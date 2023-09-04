using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;



namespace api;

public class DataBaseContext : DbContext {
    public DbSet<Card> Cards { get; set; }
    public DbSet<Column> Columns { get; set; }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
           modelBuilder.Entity<Column>().HasData(
                new Column { Id = 1, Name = "Backlog" },
                new Column { Id = 2, Name = "To Do" },
                new Column { Id = 3, Name = "Done" },
                new Column { Id = 4, Name = "Blocked" }
            );
    }
    
   
}
