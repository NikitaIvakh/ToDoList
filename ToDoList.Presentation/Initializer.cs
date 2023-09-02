using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Repositories;
using ToDoList.Domain.Entity;

namespace ToDoList.Presentation
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {

        }
    }
}