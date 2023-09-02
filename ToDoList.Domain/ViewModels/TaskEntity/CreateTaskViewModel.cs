using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels.TaskEntity
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority {  get; set; } 
    }
}