﻿namespace ToDoList.Domain.Enum
{
    public enum StatusCode
    {
        Ok = 200,

        InvalidServerError = 500,
        TaskAlreadyExists = 501,
        ThereAreNoTasks = 502,
        NoTaskIsCompleted = 503,
    }
}