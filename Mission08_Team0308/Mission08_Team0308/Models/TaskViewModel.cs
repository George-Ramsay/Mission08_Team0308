using Mission08_Assignment.Models;

namespace Mission08_Team0308.Models
{
    public class TaskViewModel
    {
        public TaskItem TaskItem { get; set; } = new TaskItem();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
