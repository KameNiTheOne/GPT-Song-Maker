namespace BlazorApp1
{
    public class TodoItem
    {
        public TodoItem(string title)
        {
            Title = title;
        }
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
