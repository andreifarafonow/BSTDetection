using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cam> Cams { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public AppDbContext() : base("DbConnection")
        {
            
        }
    }
}