using System.Collections.Generic;

namespace ToDo.Services
{
    public interface ISessionStorage
    {
        public IEnumerable<ToDoTask> LoadTasks();

        public void SaveTasks(IEnumerable<ToDoTask> tasks);
    }
}
