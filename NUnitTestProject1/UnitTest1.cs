using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace NUnitTestProject1
{
    public class Tests
    {
        TaskController controller;

        HttpConfiguration configuration;
        HttpRequestMessage request;

        public Tests()
        {
            controller = new TaskController();
            configuration = new HttpConfiguration();
            request = new HttpRequestMessage();
        }

        [Test]
        public void Add()
        {
            // Arrange
            var data = new Task()
            {
                Title = "TaskDummy",
                Description = "TaskDescription",
                ExpireDate = DateTime.Now,
                PercentComplete = "0",
                Status = "Pending"
            };
            var results = controller.Add(data);
            Assert.AreEqual("Successfully add data", results);
        }
        [Test]
        public void Update()
        {
            // Arrange
            var data = new Task()
            {
                Id = 4,
                Title = "TaskDummy",
                Description = "TaskDescription",
                ExpireDate = DateTime.Now,
                PercentComplete = "0",
                Status = "Pending"
            };
            var results = controller.Update(data);
            Assert.AreEqual("Successfully update data", results);
        }
        [Test]
        public void Delete()
        {
            // Arrange
            var results = controller.Delete(5);
            Assert.AreEqual("Successfully remove data", results);
        }
    }
}