using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo.Services;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return _taskService.GetAllTasks();
        }

        [HttpPost("Add")]
        public ToDoTask AddTask(ToDoTask task)
        {
            return _taskService.AddTask(task);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteTask(ToDoTask task)
        {
            _taskService.DeleteTask(task);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult UpdateTask(ToDoTask task)
        {
            _taskService.UpdateTask(task);
            return Ok();
        }
    }
}
