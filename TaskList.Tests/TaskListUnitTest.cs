using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using TaskList.Controllers;
using TaskList.DataContext;
using TaskList.Entities;
using Xunit;

namespace TaskList.Tests
{
    public class TaskListUnitTest : IClassFixture<TestSetup>
    {
        private ServiceProvider _serviceProvider;
        private TasksController _myController;  

        public TaskListUnitTest(TestSetup testSetup)
        {
            _serviceProvider = testSetup.ServiceProvider;
            _myController = _serviceProvider.GetService<TasksController>();       
        }   

        [Fact]
        public void Test_GetAllTask() 
        {
            var result =  _myController.GetAllTask();

            Assert.IsType<OkResult>(result.Result.Value);
        }

        [Fact]
        public void Test_CreateTask()
        {
            var newTask = new Entities.Task(){ Name = "TesteTask1", Description = "Teste Inclusão" };  

            var result = _myController.Create(newTask);          

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Test_UpdateTask()
        {
            var UpdateTask = new Entities.Task() { Name = "TesteTask2", Description = "Teste Update" };

            var result = _myController.Update(2, UpdateTask);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Test_DeleteTask()
        {
            var result = _myController.Delete(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
