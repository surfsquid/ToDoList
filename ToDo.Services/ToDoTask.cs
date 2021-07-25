using System;

namespace ToDo.Services
{
    public class ToDoTask
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool Completed { get; set; }
    }
}