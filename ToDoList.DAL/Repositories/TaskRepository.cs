using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repositories
{
    public class TaskRepository : IBaseRepository<TaskEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TaskRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(TaskEntity entity)
        {
            await _applicationDbContext.TaskEntities.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public IQueryable<TaskEntity> GetAllElements()
        {
            return _applicationDbContext.TaskEntities;
        }

        public async Task<TaskEntity> UpdateAsync(TaskEntity entity)
        {
            _applicationDbContext.TaskEntities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(TaskEntity entity)
        {
            _applicationDbContext.TaskEntities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}