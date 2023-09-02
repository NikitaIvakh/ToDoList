using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Presentation.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}