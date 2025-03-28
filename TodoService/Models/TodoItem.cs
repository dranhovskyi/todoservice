namespace TodoService.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsClosed { get; set; }
    public int Priority { get; set; }
    public int Order { get; set; }
}