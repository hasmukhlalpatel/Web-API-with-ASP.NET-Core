using Microsoft.EntityFrameworkCore;
using WebApi.Sample.Db.Entities;

namespace WebApi.Sample.Db
{
    public class SampleDbContext: DbContext, ISampleDbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> TodoLists { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(new List<Todo>() { new Todo { Id = 1, Description = "Test" } });
            modelBuilder.Entity<TodoTask>().HasData(new List<TodoTask>() { new TodoTask { Id = 1, Description = "Test task 1", Number = 1} });
        }
    }
}