using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels.TaskEntity
{
    public class GetCompletedTasksViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }
    }
}