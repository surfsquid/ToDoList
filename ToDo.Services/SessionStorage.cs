using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ToDo.Services
{
    public class SessionStorage : ISessionStorage
    {
        private IHttpContextAccessor _httpContextAccessor;

        private const string sessionTaskKey = "tasks";

        public SessionStorage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<ToDoTask> LoadTasks() 
        {
            var tasks = _httpContextAccessor.HttpContext.Session.GetString(sessionTaskKey);
            if (tasks == null)
            {
                return new List<ToDoTask>();
            }

            return JsonSerializer.Deserialize<List<ToDoTask>>(tasks);
        }

        public void SaveTasks(IEnumerable<ToDoTask> tasks) 
        {
            _httpContextAccessor.HttpContext.Session.SetString(sessionTaskKey, JsonSerializer.Serialize(tasks));
        }
    }
}
