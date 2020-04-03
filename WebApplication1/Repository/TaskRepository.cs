using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Task = WebApplication1.Models.Task;

namespace WebApplication1.Repository
{
    public class TaskRepository
    {

        public List<Task> GetTask()
        {
            var todoContext = new ToDoDbContext(); //create instance dbcontext
            return todoContext.Task.ToList(); //get all task and return it
        }
        private Task GetTaskById(int id)
        {
            var todoContext = new ToDoDbContext(); //create instance dbcontext
            var isExist = todoContext.Task.Find(id); //find list task by id
            return (Task)isExist; //return the result
        }
        public Task GetTaskByTitle(string title)
        {
            var todoContext = new ToDoDbContext(); //create instance dbcontext
            var isExist = todoContext.Task.Where(x => x.Title.ToLower() == title);//find list task by title
            return isExist.FirstOrDefault();  //return the result
        }
        public List<Task> GetIncomingTask(string status)
        {
            var temp = new List<Task>();//create instance list task
            var todoContext = new ToDoDbContext();//create instance dbcontext
            var allTask = todoContext.Task.ToList(); //get all task from db

            if (status.ToLower() == "currentweek") //check if status 
            {
                var todaydate = DateTime.Now; //get date today
                var thisWeekStart = todaydate.AddDays(-(int)todaydate.DayOfWeek); //get start week date
                var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1); //get latest week date
                temp = allTask.Where(x => x.ExpireDate > thisWeekStart && x.ExpireDate < thisWeekEnd).ToList(); //filter alltask where expiredate in current week
            }
            else if (status.ToLower() == "nextday")
            {
                var todaydate = DateTime.Now.AddDays(1).ToShortDateString();//get next day
                temp = allTask.Where(x => x.ExpireDate.ToShortDateString().Equals(todaydate)).ToList(); //filter alltask where expired date is next day
            }
            else if (status.ToLower() == "today")
            {
                var todaydate = DateTime.Now.ToShortDateString();//get next day
                temp = allTask.Where(x => x.ExpireDate.ToShortDateString().Equals(todaydate)).ToList(); //filter alltask where expired date is to day
            }

            return temp;
        }
        public string Delete(int id)
        {
            var todoContext = new ToDoDbContext();//create instance dbcontext
            var existingData = GetTaskById(id); //get contact by id
            if (existingData == null) //chec if null
                return $@"Data with id { id } not found"; //return result

            try
            {
                todoContext.Remove<Task>(existingData); //remove data
                todoContext.SaveChanges(); //commit save change
            }
            catch (Exception)
            {
                return "Failed remove data";//return result
            }
            return "Successfully remove data";//return result
        }
        public string Add(Task model)
        {
            var todoContext = new ToDoDbContext();//create instance dbcontext
            try
            {
                todoContext.Add(model); //save model to database 
                todoContext.SaveChanges(); //commit save change
            }
            catch (Exception e)
            {
                return "Failed add data";  //return result
            }
            return "Successfully add data";//return result
        }
        public string Update(Task model)
        {
            var todoContext = new ToDoDbContext();//create instance dbcontext
            try
            {
                todoContext.Update(model); //update model to dataabse
                todoContext.SaveChanges();//commit save change
            }
            catch (Exception e)
            {
                return "Failed when update data";//return result
            }
            return "Successfully update data";//return result
        }
        public string UpdateTaskCompleted(int id)
        {
            var todoContext = new ToDoDbContext(); //create instance dbcontext
            try
            {
                var dataExist = GetTaskById(id); //find task by id 
                if (dataExist != null)
                {
                    dataExist.PercentComplete = "100"; //set property
                    todoContext.Update(dataExist); //jpdate model to database
                    todoContext.SaveChanges(); //commit save change
                }
                else
                {
                    return "Failed when process data"; //return result
                }
            }
            catch (Exception e)
            {
                return "Failed when update data"; //return result
            }
            return "Successfully update data"; //return result
        }
        public string MarkTaskDone(int id)
        {
            var todoContext = new ToDoDbContext();//create instance dbcontext
            try
            {
                var dataExist = GetTaskById(id); //get task by id
                if (dataExist != null) //check if not null
                {
                    dataExist.Status = "Done"; //set property
                    todoContext.Update(dataExist); //update model to database
                    todoContext.SaveChanges();//commit save change
                }
                else
                {
                    return "Failed when process data";//return result
                }
            }
            catch (Exception e)
            {
                return "Failed when update data";//return result
            }
            return "Successfully update data";//return result
        }
    }
}
