using System.ComponentModel.DataAnnotations;

namespace Mission08_Assignment.Models
{
    // We use TaskItem instead of Task to avoid conflict with System.Threading.Tasks.Task
    public class TaskItem
    {
        [Key] // Primary Key
        public int TaskItemId { get; set; }

        [Required] // Required field per assignment
        public string Task { get; set; } = string.Empty;

        // Optional due date
        public DateTime? DueDate { get; set; }

        [Required] // Must choose Quadrant 1-4
        [Range(1, 4)]
        public int Quadrant { get; set; }

        // Foreign Key to Category table
        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }

        // True/False for completed
        public bool Completed { get; set; } = false;
    }
}