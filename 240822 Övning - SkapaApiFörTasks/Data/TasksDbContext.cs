using _240822_Övning___SkapaApiFörTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace _240822_Övning___SkapaApiFörTasks.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        public DbSet<ToDoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoTask>().HasData
            (
                new ToDoTask { Id = 1, Title = "Create your first task!", Description = "Add your first task to the list, and then get working!", Status = "Not completed"}
            );
        }
    }
}
