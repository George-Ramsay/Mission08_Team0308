using System.ComponentModel.DataAnnotations;

namespace Mission08_Assignment.Models
{
    // This represents the Category table (Home, School, Work, Church)
    public class Category
    {
        [Key] // Primary Key
        public int CategoryId { get; set; }

        [Required] // Cannot be null
        public string CategoryName { get; set; } = string.Empty;
    }
}