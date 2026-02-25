using Microsoft.EntityFrameworkCore;
using Mission08_Assignment.Data;
using Mission08_Assignment.Models;

namespace Mission08_Assignment.Repositories
{
    // Concrete implementation using Entity Framework
    public class EFQuadrantsRepository : IQuadrantsRepository
    {
        private readonly QuadrantsContext _context;

        // Inject DbContext
        public EFQuadrantsRepository(QuadrantsContext context)
        {
            _context = context;
        }

        // Include Category so dropdown name works
        public IQueryable<TaskItem> TaskItems =>
            _context.TaskItems.Include(t => t.Category);

        public IQueryable<Category> Categories =>
            _context.Categories;

        public void AddTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _context.TaskItems.Update(task);
        }

        public void DeleteTask(TaskItem task)
        {
            _context.TaskItems.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}