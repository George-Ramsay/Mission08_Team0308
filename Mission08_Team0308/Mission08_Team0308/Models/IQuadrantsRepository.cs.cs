using Mission08_Assignment.Models;

namespace Mission08_Assignment.Repositories
{
    // Interface defines what database operations are allowed
    public interface IQuadrantsRepository
    {
        IQueryable<TaskItem> TaskItems { get; }
        IQueryable<Category> Categories { get; }

        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
        void SaveChanges();
    }
}