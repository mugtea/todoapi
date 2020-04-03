using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase //inherit controller base
    {
        private TaskRepository taskRepository; //declare variable taskrepository

        public TaskController()
        {
            taskRepository = new TaskRepository(); //instance the variable to TaskRepository class
        }
        // GET: api/Task
        [HttpGet("GetAllTask")] //set routing name of api
        public List<Task> GetAllTask()
        {
            return taskRepository.GetTask(); //call repostiory and return the result
        }
        [HttpGet("GetTaskByTitle")] //set routing name of api
        public Task GetAllTask(string title)
        {
            return taskRepository.GetTaskByTitle(title);//call repostiory and return the result
        }
        [HttpGet("GetIncomingTask")] //set routing name of api
        public List<Task> GetIncomingTask(string status)
        {
            return taskRepository.GetIncomingTask(status);//call repostiory and return the result
        }
        [HttpGet("UpdateTaskComplete")] //set routing name of api
        public string UpdateTaskComplete(int id)
        {
            return taskRepository.MarkTaskDone(id);//call repostiory and return the result
        }
        [HttpGet("MarkTaskDone")] //set routing name of api
        public string MarkTaskDone(int id)
        {
            return taskRepository.MarkTaskDone(id);//call repostiory and return the result
        }
        [HttpPost("AddTask")] //set routing name of api
        public string Add([FromBody] Task model)
        {
            return taskRepository.Add(model);//call repostiory and return the result
        }
        [HttpPost("UpdateTask")] //set routing name of api
        public string Update([FromBody] Task model)
        {
            return taskRepository.Update(model);//call repostiory and return the result
        }
        [HttpGet("Delete")] //set routing name of api
        public string Delete(int id)
        {
            return taskRepository.Delete(id);//call repostiory and return the result
        }
    }
}
