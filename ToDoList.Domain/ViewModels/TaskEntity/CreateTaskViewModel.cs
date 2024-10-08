﻿using ToDoList.Domain.Enum;

namespace ToDoList.Domain.ViewModels.TaskEntity
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(Name, "Specify the name of your task");

            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentNullException(Description, "Specify the description of your task");
        }
    }
}