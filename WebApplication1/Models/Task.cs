using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Task
    {
        public Task()
        {
            Status = "Pending";
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string PercentComplete { get; set; }
        public string Status { get; set; }
    }
}
