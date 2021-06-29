using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Models;
using System.Linq;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        static List<TaskItem> taskItems = new List<TaskItem>()
            {
                new TaskItem(){
                    Title = "Task 1",
                    Iscompleted = false
                },
                new TaskItem(){
                    Title = "Task 2",
                    Iscompleted = false
                },
                new TaskItem(){
                    Title = "Task 3",
                    Iscompleted = false
                }
            };
        [HttpGet]
        public IEnumerable<TaskItem> GetListTask()
        {
            return taskItems;
        }
        [HttpPost]
        public List<TaskItem> CreateTaskItem(TaskItem taskItem)
        {
            taskItem.Id = Guid.NewGuid();
            taskItems.Add(taskItem);
            return taskItems;
        }
        [HttpGet("id")]
        public TaskItem GetTaskById(Guid id)
        {
            var TaskItem = taskItems.FirstOrDefault(t => t.Id == id);
            return TaskItem;
        }
        [HttpPost("id")]
        public List<TaskItem> UpdateTaskById(Guid id)
        {
            var TaskItem = taskItems.FirstOrDefault(t => t.Id == id);
            TaskItem.Iscompleted = true;
            return taskItems;
        }
        [HttpDelete("id")]
        public List<TaskItem> DeleteTaskById(Guid id)
        {
            var TaskItem = taskItems.FirstOrDefault(t => t.Id == id);
            taskItems.Remove(TaskItem);
            return taskItems;
        }
    }
}