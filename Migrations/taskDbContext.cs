

using Microsoft.EntityFrameworkCore;
using task_api.Models;

namespace task_api.Migrations;

public class taskDbContext : DbContext
{
    public DbSet<task> task {get; set;}
    public taskDbContext(DbContextOptions<taskDbContext> options)
    :base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<task>(entity=>
        {
            entity.HasKey(e => e.TaskId);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Completed).IsRequired();

        });

        modelBuilder.Entity<task>().HasData(
            new task{
                TaskId = 1,
                Title = "greeting",
                Completed = false
            },
            new task {
                TaskId = 2,
                Title = "go to school",
                Completed= true
            }

        );
    }
}
