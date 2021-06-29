using System;
using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Models
{
     public class TaskItem
    {
        public Guid Id { get; set;}
        public string Title { get; set; }
        public Boolean Iscompleted { get; set; }
    }
}