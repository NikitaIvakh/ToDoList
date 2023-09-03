using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.ViewModels.TaskEntity
{
    public class TaskViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Readiness")]
        public string IsCompleted { get; set; }

        [Display(Name = "Priority")]
        public string Priority { get; set; }

        [Display(Name = "Date created")]
        public string DateCreated { get; set; }
    }
}