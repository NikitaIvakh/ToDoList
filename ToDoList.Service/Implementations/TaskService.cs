using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ToDoList.DAL.Interfaces;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Expansion;
using ToDoList.Domain.Response;
using ToDoList.Domain.ViewModels.TaskEntity;
using ToDoList.Service.Interfaces;

namespace ToDoList.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskEntityRepository;
        private readonly ILogger<TaskService> _logger;

        public TaskService(IBaseRepository<TaskEntity> taskEntityRepository, ILogger<TaskService> logger)
        {
            _taskEntityRepository = taskEntityRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<TaskEntity>> CreateTaskAsync(CreateTaskViewModel createTaskViewModel)
        {
            try
            {
                _logger.LogInformation($"Request to create a task: {createTaskViewModel.Name}");
                var task = await _taskEntityRepository.GetAllElements()
                    .Where(key => key.DateCreated.Date == DateTime.Today)
                    .FirstOrDefaultAsync(key => key.Name == createTaskViewModel.Name);

                if (task is not null)
                {
                    return new BaseResponse<TaskEntity>
                    {
                        Description = $"Such a task already exists",
                        StatusCode = StatusCode.TaskAlreadyExists,
                    };
                }

                task = new TaskEntity
                {
                    Name = createTaskViewModel.Name,
                    Description = createTaskViewModel.Description,
                    IsCompleted = false,
                    Priority = createTaskViewModel.Priority,
                    DateCreated = DateTime.UtcNow,
                };

                await _taskEntityRepository.CreateAsync(task);

                _logger.LogInformation($"The task has been added: {task.Name} - {task.DateCreated}");
                return new BaseResponse<TaskEntity>
                {
                    Description = "The task has been added",
                    StatusCode = StatusCode.Ok,
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.CreateTaskAsync] : {ex.Message}");
                return new BaseResponse<TaskEntity>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InvalidServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetAllTasksAsync()
        {
            try
            {
                var tasks = _taskEntityRepository.GetAllElements().Select(key => new TaskViewModel
                {
                    Id = key.Id,
                    Name = key.Name,
                    Description = key.Description,
                    Priority = key.Priority.GetDisplayName(),
                    IsCompleted = key.IsCompleted == true ? "Task completed" : "Task not completed",
                    DateCreated = key.DateCreated.ToLongDateString(),
                });

                if (tasks is null)
                {
                    return new BaseResponse<IEnumerable<TaskViewModel>>
                    {
                        Description = $"There are no tasks",
                        StatusCode = StatusCode.ThereAreNoTasks,
                    };
                };

                _logger.LogInformation($"[TaskService.GetAllTasks] elements received: {tasks.Count()}");
                return new BaseResponse<IEnumerable<TaskViewModel>>
                {
                    Data = tasks,
                    StatusCode = StatusCode.Ok,
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.GetAllTasks] : {ex.Message}");
                return new BaseResponse<IEnumerable<TaskViewModel>>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InvalidServerError,
                };
            }
        }

        public async Task<IBaseResponse<TaskViewModel>> GetTaskAsync(int id)
        {
            try
            {
                var task = await _taskEntityRepository.GetAllElements().Select(key => new TaskViewModel
                {
                    Id = key.Id,
                    Name = key.Name,
                    Description = key.Description,
                    IsCompleted = key.IsCompleted == true ? "Task completed" : "Task not completed",
                    Priority = key.Priority.GetDisplayName(),
                    DateCreated = key.DateCreated.ToLongDateString(),
                }).FirstOrDefaultAsync(key => key.Id == id);

                if (task is null)
                {
                    return new BaseResponse<TaskViewModel>
                    {
                        Description = "Task not found",
                        StatusCode = StatusCode.TaskNotFound,
                    };
                }

                return new BaseResponse<TaskViewModel>
                {
                    Data = task,
                    StatusCode = StatusCode.Ok,
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.GetTaskAsync] : {ex.Message}");
                return new BaseResponse<TaskViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InvalidServerError,
                };
            }
        }

        public async Task<IBaseResponse<bool>> EndTaskAsync(int id)
        {
            try
            {
                var task = await _taskEntityRepository.GetAllElements().FirstOrDefaultAsync(key => key.Id == id);
                if (task is null)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Description = "Task not found",
                        StatusCode = StatusCode.TaskNotFound,
                    };
                }

                task.IsCompleted = true;
                await _taskEntityRepository.UpdateAsync(task);

                return new BaseResponse<bool>
                {
                    Data = true,
                    Description = "The task was successfully deleted",
                    StatusCode = StatusCode.Ok,
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.EndTaskAsync]: {ex.Message}");
                return new BaseResponse<bool>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InvalidServerError,
                };
            }
        }
    }
}