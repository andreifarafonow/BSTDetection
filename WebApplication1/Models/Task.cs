using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public int CamId { get; set; }

        public bool IsComplete { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}