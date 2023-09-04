using ToDoList.Domain.Entity;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.TaskEntity;

namespace ToDoList.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponse<TaskEntity>> CreateTaskAsync(CreateTaskViewModel createTaskViewModel);

        Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetAllTasksAsync();

        Task<IBaseResponse<TaskViewModel>> GetTaskAsync(int id);

        Task<IBaseResponse<bool>> EndTaskAsync(int id);
    }
}