using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ToDoList.Domain.Filters.Task;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.ViewModels.TaskEntity;
using ToDoList.Service.Interfaces;

namespace ToDoList.Presentation.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> TaskHandler(TaskFilter taskFilter)
        {
            var response = await _taskService.GetAllTasksAsync(taskFilter);
            return Json(new { data = response.Data });
        }

        [HttpGet]
        public async Task<IActionResult> GetTask(int id)
        {
            var response = await _taskService.GetTaskAsync(id);
            return PartialView(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompletedTask()
        {
            var response = await _taskService.GetCompletedTaskAsync();
            return Json(new { data = response.Data });
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel createTaskViewModel)
        {
            var response = await _taskService.CreateTaskAsync(createTaskViewModel);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> EndTask(int id)
        {
            var response = await _taskService.EndTaskAsync(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> CalculateCompletedTasks()
        {
            var response = await _taskService.CalculateCompletedTasksAsync();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                var csvService = new CsvBaseService<IEnumerable<TaskViewModel>>();
                var uploadFile = csvService.UploadFile(response.Data);

                return File(uploadFile, "text/csv", $"Statistics for {DateTime.Now.ToString(CultureInfo.InvariantCulture)}.csv");
            }

            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public JsonResult GetPrioritry()
        {
            var response = _taskService.GetPrioritry();
            return Json(response.Data);
        }
    }
}