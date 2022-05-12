using Microsoft.EntityFrameworkCore;
using WebApi.Sample.Db.Entities;

namespace WebApi.Sample.Db;

public interface ISampleDbContext
{
    DbSet<Todo> TodoLists { get; set; }
    DbSet<TodoTask> TodoTasks { get; set; }

}