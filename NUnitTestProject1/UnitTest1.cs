using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace NUnitTestProject1
{
    public class Tests
    {
        //create dummmy data in memory data
        IQueryable<Task> listTasks = new List<Task>
            {
                new Task
                {
                    Id = 1,
                    Title = "Task1",
                    Description = "Desc1",
                    ExpireDate = DateTime.Now,
                    PercentComplete = "0",
                    Status = "Pending"
                },
                new Task
                {
                    Id = 2,
                    Title = "Task2",
                    Description = "Desc2",
                    ExpireDate = DateTime.Now.AddDays(1),
                    PercentComplete = "0",
                    Status = "Pending"
                }
            }.AsQueryable();


        [SetUp]
        public void Setup()
        {
        }

        //[TestMethod]
        //public void CreateBookTest()
        //{
        //    var mockSet = new Mock<DbSet<Task>>();

        //    var mockContext = new Mock<ToDoDbContext>();
        //    mockContext.Setup(m => m.Task).Returns(mockSet.Object);

        //    // Act - Add the book
        //    var repository = new TaskRepository(mockContext.Object);
        //    repository.AddBook("Macbeth", "William Shakespeare");

        //    // Assert
        //    // These two lines of code verifies that a book was added once and
        //    // we saved our changes once.
        //    mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once);
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once);
        //}
    }
}