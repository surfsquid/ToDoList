using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo.Services
{
    public class TaskService : ITaskService
    {
        private ISessionStorage _sessionStorage;

        public TaskService(ISessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public ToDoTask AddTask(ToDoTask task)
        {
            var tasks = _sessionStorage.LoadTasks().ToList();
            task.Id = Guid.NewGuid();
            tasks.Add(task);
            _sessionStorage.SaveTasks(tasks);
            return task;
        }

        public void DeleteTask(ToDoTask task)
        {
            var tasks = _sessionStorage.LoadTasks().ToList();
            tasks.RemoveAll(t => t.Id == task.Id);
            _sessionStorage.SaveTasks(tasks);
        }

        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return _sessionStorage.LoadTasks();
        }

        public ToDoTask UpdateTask(ToDoTask task)
        {
            var tasks = _sessionStorage.LoadTasks();
            var storedTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (storedTask != null)
            {
                storedTask.Completed = task.Completed;
                storedTask.Text = task.Text;
            }

            _sessionStorage.SaveTasks(tasks);
            return storedTask;
        }
    }
}
