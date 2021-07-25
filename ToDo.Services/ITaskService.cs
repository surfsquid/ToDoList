using System.Collections.Generic;

namespace ToDo.Services
{
    public interface ITaskService
    {
        IEnumerable<ToDoTask> GetAllTasks();

        ToDoTask AddTask(ToDoTask task);

        ToDoTask UpdateTask(ToDoTask task);

        void DeleteTask(ToDoTask task);
    }
}