using Microsoft.EntityFrameworkCore;
using TodoService.Data;
using TodoService.Models;
using TodoService.Repositories.Interfaces;

namespace TodoService.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> AddItemAsync(TodoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(TodoItem item)
    {
        _context.TodoItems.Update(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return false;

        _context.TodoItems.Remove(item);
        return await _context.SaveChangesAsync() > 0;
    }
}