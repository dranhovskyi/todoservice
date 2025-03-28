using Microsoft.EntityFrameworkCore;
using TodoService.Models;

namespace TodoService.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
}