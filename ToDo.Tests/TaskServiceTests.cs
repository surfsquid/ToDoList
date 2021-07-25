using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using ToDo.Services;
using Xunit;

namespace ToDo.Tests
{
    public class TaskServiceTests
    {
        private Mock<ISessionStorage> _mockSessionService;
        private TaskService _target;
        private List<ToDoTask> _testTasks;

        public TaskServiceTests()
        {
            _mockSessionService = new Mock<ISessionStorage>();
            _target = new TaskService(_mockSessionService.Object);
            _testTasks = new List<ToDoTask> { new ToDoTask { Id = Guid.NewGuid(), Completed = false, Text = "this is just a test" } };
            _mockSessionService.Setup(x => x.LoadTasks()).Returns(_testTasks);

        }

        [Fact]
        public void GetAllTasks_ReturnsListOfTasks_FromSessionStorage()
        {
            // Act
            var result = _target.GetAllTasks();

            // Assert
            result.ShouldBe(_testTasks);
        }

        [Fact]
        public void AddTask_RetrievesTasks_FromSessionStorage()
        {
            // Act
            var result = _target.AddTask(new ToDoTask());

            // Assert
            _mockSessionService.Verify(x => x.LoadTasks(), Times.Once());
        }

        [Fact]
        public void AddTask_SavesTasks_ToSessionStorage()
        {
            // Act
            var result = _target.AddTask(new ToDoTask());

            // Assert
            _mockSessionService.Verify(x => x.SaveTasks(It.IsAny<List<ToDoTask>>()), Times.Once());
        }

        [Fact]
        public void UpdateTask_PersistsStatusChange_ToSessionStorage()
        {
            var guid = Guid.NewGuid();
            var incompleteTestTask = new ToDoTask { Id = guid, Text = "complete this task", Completed = false };
            var completeTestTask = new ToDoTask { Id = guid, Text = "complete this task", Completed = true };
            _mockSessionService.Setup(x => x.LoadTasks()).Returns(new List<ToDoTask> { incompleteTestTask });

            // Act
            var result = _target.UpdateTask(completeTestTask);

            // Assert
            _mockSessionService.Verify(x => x.SaveTasks(It.IsAny<List<ToDoTask>>()), Times.Once());
        }
    }
}
