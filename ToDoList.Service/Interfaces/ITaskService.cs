using ToDoList.Domain.Entity;
using ToDoList.Domain.Filters.Task;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.TaskEntity;

namespace ToDoList.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponse<TaskEntity>> CreateTaskAsync(CreateTaskViewModel createTaskViewModel);

        Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetAllTasksAsync(TaskFilter taskFilter);

        Task<IBaseResponse<TaskViewModel>> GetTaskAsync(int id);

        Task<IBaseResponse<bool>> EndTaskAsync(int id);

        Task<IBaseResponse<IEnumerable<GetCompletedTasksViewModel>>> GetCompletedTaskAsync();

        Task<IBaseResponse<IEnumerable<TaskViewModel>>> CalculateCpmpletedTasksAsync();

        IBaseResponse<IDictionary<int, string>> GetPrioritry();
    }
}